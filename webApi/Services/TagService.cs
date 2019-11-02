using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using webApi.Contracts;
using webApi.Models;

namespace webApi.Services
{
    public class TagService : ITagService
    {
        private const string TagsPath = "Data/tags.json";
        private const string ArticleTagsPath = "Data/article-tags.json";

        public TagService()
        {

        }

        public List<TagModel> GetAllTags()
        {
            using (StreamReader r = new StreamReader(TagsPath))
            {
                string json = r.ReadToEnd();

                List<TagModel> items =
                    JsonConvert.DeserializeObject<List<TagModel>>(json);

                return items;
            }
        }

        public ArticleTagModel GetTagsByArticleId(int articleId)
        {
            List<TagModel> allTags = GetAllTags();

            using (StreamReader r = new StreamReader(ArticleTagsPath))
            {
                string json = r.ReadToEnd();

                ArticleTagModel articleTags =
                    JsonConvert.DeserializeObject<List<ArticleTagModel>>(json)
                    .Where(x => x.ArticleId == articleId).FirstOrDefault();

                foreach (var tagId in articleTags.TagIds)
                {
                    var tag = FindTagById(allTags, tagId);
                    if (tag != null)
                    {
                        articleTags.Tags.Add(tag);
                    }
                }

                articleTags.Tags.ForEach(x => x.Tags = null);
                articleTags.TagIds = articleTags.TagIds.OrderBy(x => x).ToList();
                articleTags.Tags = articleTags.Tags.OrderBy(x => x.Id).ToList();

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

        public TagModel FindTagById(List<TagModel> tags, int tagId)
        {
            TagModel model = null;

            if (tags != null)
            {
                if (tags.Any(x => x.Id == tagId))
                {
                    model = tags.Where(x => x.Id == tagId).FirstOrDefault();
                }
                else
                {
                    model = FindTagByIdInner(tags, tagId, 0);
                }
            }

            return model;
        }

        public TagModel FindTagByIdInner(List<TagModel> tags, int tagId, int listIndexToCheck)
        {
            TagModel model = null;

            while (tags != null && listIndexToCheck < tags.Count && model == null)
            {
                if (tags[listIndexToCheck].Tags != null)
                {
                    model = tags[listIndexToCheck].Tags.Where(x => x.Id == tagId).FirstOrDefault();

                    if (model == null)
                    {
                        model = FindTagByIdInner(tags[listIndexToCheck].Tags, tagId, listIndexToCheck);
                    }
                }

                listIndexToCheck++;
            }

            return model;
        }
    }
}