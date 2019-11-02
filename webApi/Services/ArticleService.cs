using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using webApi.Contracts;
using webApi.Models;

namespace webApi.Services
{
    public class ArticleService : IArticleService
    {
        private const string Path = "Data/articles.json";

        private readonly ITagService _tagService;

        public ArticleService(ITagService tagService)
        {
            _tagService = tagService;
        }

        public List<ArticleModel> GetArticles()
        {
            using (StreamReader r = new StreamReader(Path))
            {
                string json = r.ReadToEnd();

                List<ArticleModel> items =
                    JsonConvert.DeserializeObject<List<ArticleModel>>(json);
                return items;
            }
        }

        public List<ArticleModelSummary> GetArticlesSummary()
        {
            using (StreamReader r = new StreamReader(Path))
            {
                string json = r.ReadToEnd();

                List<ArticleModelSummary> items =
                    JsonConvert.DeserializeObject<List<ArticleModelSummary>>(json);
                return items;
            }
        }

        public List<ArticleModelSummary> GetArticlesSummaryByTagPath(string tagPath)
        {
            if (!tagPath.StartsWith('/'))
            {
                tagPath = "/" + tagPath;
            }
            var flattenedTags = _tagService.GetFlattenedTags(null);

            if (!flattenedTags.Any(x => x.Path == tagPath))
            {
                return null;
            }

            List<ArticleModelSummary> returnModel = new List<ArticleModelSummary>();
            var summaryModel = GetArticlesSummary();

            var tag = flattenedTags.Where(x => x.Path == tagPath).FirstOrDefault();

            if (tag != null)
            {
                foreach (var articleSummary in summaryModel)
                {
                    ArticleTagModel articleTags = _tagService.GetTagsByArticleId(articleSummary.Id);

                    if (articleTags.Tags.Any(x => x.Path == tag.Path))
                    {
                        returnModel.Add(articleSummary);
                    }
                }
            }
            return returnModel;
        }

        public ArticleModel GetArticle(int id)
        {
            using (StreamReader r = new StreamReader(Path))
            {
                string json = r.ReadToEnd();

                // dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                // JArray articlesArray = (JArray)jsonObj;
                // var articleJToken = articlesArray.FirstOrDefault(x => x["id"].Value<int>() == id).FirstOrDefault();

                // ArticleModel model = new ArticleModel();

                // model.Id = articleJToken.Parent.Value<int>("id");
                // model.Title = articleJToken.Parent.Value<string>("title");
                // model.SubTitle = articleJToken.Parent.Value<string>("subTitle");
                // model.Summary = articleJToken.Parent.Value<string>("summary");
                // model.HeaderImage = articleJToken.Parent.Value<string>("headerImage");
                // model.Content = articleJToken.Parent.Value<string>("content");
                // model.Author = articleJToken.Parent.Value<string>("author");
                // model.PublishDate = articleJToken.Parent.Value<DateTime>("publishDate");
                // model.Views = articleJToken.Parent.Value<int>("views");
                // model.Tags =  articleJToken.Parent.Value<JArray>("tags").ToObject<List<int>>();

                var model =
                    JsonConvert.DeserializeObject<List<ArticleModel>>(json)
                    .Where(x => x.Id == id).FirstOrDefault();

                if (model != null && model.Id > 0)
                {
                    UpdateViewCount(id);
                }

                return model;
            }
        }

        public void UpdateViewCount(int id)
        {
            string json = File.ReadAllText(Path);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            JArray articlesArray = (JArray)jsonObj;

            int currentViewCount = articlesArray
                                    .FirstOrDefault(x => x["id"].Value<int>() == id)["views"].Value<int>();

            int newViewCount = currentViewCount;
            newViewCount++;

            articlesArray.FirstOrDefault(x => x["id"].Value<int>() == id)["views"] = newViewCount;

            jsonObj = articlesArray;

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Path, output);
        }
    }
}