using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using webApi.Contracts;
using webApi.Models;

namespace webApi.Services
{
    public class TagService : ITagService
    {
        private const string TagsPath = "Data/tags.json";
        private const string ArticleTagsPath = "Data/article-tags.json";

        public List<TagModel> GetFlattenedTags(List<TagModel> model = null, bool keepChildren = false)
        {
            model = model ?? GetAllTags();

            model = model.Flatten(c => c.Tags).ToList();

            if (!keepChildren)
            {
                model.ForEach(x => x.Tags = null);
            }

            return model.OrderBy(x => x.SortOrder).ToList();
        }

        public List<TagModel> GetAllTags()
        {
            var model = JSONHelper.Deseriaize(TagsPath, new List<TagModel>());
            model = BuildTagPaths(model, null).OrderBy(x => x.SortOrder)
                .ToList();
            return model;
        }

        public ArticleTagModel GetTagsByArticleId(int articleId)
        {
            using (StreamReader r = new StreamReader(ArticleTagsPath))
            {
                string json = r.ReadToEnd();

                ArticleTagModel articleTags =
                    JsonConvert.DeserializeObject<List<ArticleTagModel>>(json)
                    .Where(x => x.ArticleId == articleId).FirstOrDefault();

                if (articleTags != null && articleTags.TagIds.Count > 0)
                {
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
                }

                return articleTags;
            }
        }

        public void CreateArticleTags(ArticleTagModel model)
        {
            JSONHelper.CreateJSONElement(ArticleTagsPath, model);
        }

        public void UpdateArticleTags(ArticleTagModel model)
        {
            JSONHelper.UpdateJSONElement(ArticleTagsPath, "articleId", model, model.ArticleId);
        }

        public List<string> TagPathToTagPathList(string tagPath)
        {
            List<string> tagPaths = tagPath.ToString().Split(',').ToList();
            return tagPaths;
        }

        public string SetTagPath(List<string> tagPaths)
        {
            string tagPath = tagPaths.Count == 1 ?
                tagPaths.FirstOrDefault() : string.Join("/", tagPaths);

            if (!tagPath.StartsWith('/'))
            {
                tagPath = "/" + tagPath;
            }

            return tagPath;
        }

        public bool TagPathRootSearch(List<string> tagPaths)
        {
            return tagPaths.Count == 1;
        }

        public bool TagPathRootSearch(string tagPath)
        {
            return tagPath.Count(x => x == '/') == 1;
        }

        public TagModel FindTagByPath(string tagPath)
        {
            TagModel tag = null;
            var flattenedTags = GetFlattenedTags();

            if (!flattenedTags.Any(x => x.Path == tagPath))
            {
                return null;
            }

            tag = flattenedTags.Where(x => x.Path == tagPath).FirstOrDefault();

            return tag;
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
}