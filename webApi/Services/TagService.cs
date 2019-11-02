using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using webApi.Contracts;
using webApi.Models;
using System;

namespace webApi.Services
{
    public class TagService : ITagService
    {
        private const string TagsPath = "Data/tags.json";
        private const string ArticleTagsPath = "Data/article-tags.json";

        public TagService()
        {

        }

        public List<TagModel> GetFlattenedTags(List<TagModel> model)
        {
            if (model == null)
            {
                model = GetAllTags();
            }

            model = model.Flatten(c => c.Tags).ToList();

            model.ForEach(x => x.Tags = null);
            model = model.OrderBy(x => x.SortOrder).ToList();

            return model;
        }

        public List<TagModel> GetAllTags()
        {
            using (StreamReader r = new StreamReader(TagsPath))
            {
                string json = r.ReadToEnd();

                List<TagModel> tags =
                    JsonConvert.DeserializeObject<List<TagModel>>(json);

                tags = BuildTagPaths(tags, null);

                tags = tags.OrderBy(x => x.SortOrder).ToList();

                return tags;
            }
        }

        public ArticleTagModel GetTagsByArticleId(int articleId)
        {
            using (StreamReader r = new StreamReader(ArticleTagsPath))
            {
                string json = r.ReadToEnd();

                ArticleTagModel articleTags =
                    JsonConvert.DeserializeObject<List<ArticleTagModel>>(json)
                    .Where(x => x.ArticleId == articleId).FirstOrDefault();

                var flattenedTags = GetFlattenedTags(null);

                foreach (var tagId in articleTags.TagIds)
                {
                    var tag = FindTagById(flattenedTags, tagId);
                    if (tag != null)
                    {
                        articleTags.Tags.Add(tag);
                    }
                }

                articleTags.Tags.ForEach(x => x.Tags = null);
                articleTags.TagIds = articleTags.TagIds.OrderBy(x => x).ToList();
                articleTags.Tags = articleTags.Tags.OrderBy(x => x.Path).ToList();

                return articleTags;
            }
        }

        public void UpdateArticleTags(ArticleTagModel model)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializerSettings.Formatting = Formatting.Indented;

            string json = File.ReadAllText(ArticleTagsPath);

            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json, serializerSettings);

            JArray articleTags = (JArray)jsonObj;

            var newjToken = JToken.FromObject(model);

            articleTags
                .Where(x => x["articleId"].Value<int>() == model.ArticleId)
                .FirstOrDefault().Replace(newjToken);

            jsonObj = articleTags;

            string output = Newtonsoft.Json.JsonConvert
                    .SerializeObject(jsonObj, serializerSettings.Formatting, serializerSettings);

            File.WriteAllText(ArticleTagsPath, output);
        }

        private List<TagModel> BuildTagPaths(List<TagModel> tags, string path)
        {
            List<TagModel> tagsWithPaths = new List<TagModel>();

            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    var newTag = new TagModel();
                    newTag.Id = tag.Id;
                    newTag.Title = tag.Title;
                    newTag.ShowInNav = tag.ShowInNav;
                    newTag.SortOrder = tag.SortOrder;
                    newTag.Path = FormatPath(tag.Title);
                    newTag.Tags = tag.Tags;

                    if (tag.Tags != null)
                    {
                        List<TagModel> newChildTags = BuildTagPathsInner(newTag, newTag.Path);
                        if (newChildTags != null)
                        {
                            newTag.Tags = new List<TagModel>();
                            newTag.Tags = newChildTags;
                        }
                    }

                    tagsWithPaths.Add(newTag);
                }
            }
            return tagsWithPaths;
        }

        private List<TagModel> BuildTagPathsInner(TagModel tag, string path)
        {
            List<TagModel> newChildTags = new List<TagModel>();

            if (tag.Tags != null)
            {
                foreach (var childTag in tag.Tags)
                {
                    childTag.Path = FormatPath(path + "/" + childTag.Title);
                    if (childTag.Tags != null)
                    {
                        childTag.Tags = BuildTagPathsInner(childTag, childTag.Path);
                    }

                    newChildTags.Add(childTag);
                }
            }

            return newChildTags;
        }

        private TagModel FindTagById(List<TagModel> tags, int tagId)
        {
            TagModel model = null;

            if (tags != null)
            {
                if (tags.Any(x => x.Id == tagId))
                {
                    model = tags.Where(x => x.Id == tagId).FirstOrDefault();
                }
            }

            return model;
        }

        private string FormatPath(string path)
        {
            path = path.ToLower().Replace(" ", "-");

            if (!path.StartsWith('/'))
            {
                path = "/" + path;
            }

            return path;
        }
    }

    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Flatten<T>(
            this IEnumerable<T> items,
            Func<T, IEnumerable<T>> getChildren)
        {
            if (items == null)
            {
                yield break;
            }

            var stack = new Stack<T>(items);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current;

                if (current == null) continue;

                var children = getChildren(current);
                if (children == null) continue;

                foreach (var child in children)
                    stack.Push(child);
            }
        }
    }
}