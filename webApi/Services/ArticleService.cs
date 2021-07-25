using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using webApi.Contracts.Articles;
using webApi.Contracts.Articles.Tags;
using webApi.Models.Articles;
using webApi.Models.Articles.Tags;

namespace webApi.Services.Articles
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
            var model = JSONHelper.Deseriaize(Path, new List<ArticleModel>());
            return model;
        }

        public List<ArticleSummaryModel> GetArticlesSummary()
        {
            var model = JSONHelper.Deseriaize(Path, new List<ArticleSummaryModel>());
            return model;
        }

        public List<ArticleSummaryModel> GetArticlesSummaryByTagPath(string tagPath)
        {
            tagPath = _tagService.SetTagPath(_tagService.TagPathToTagPathList(tagPath));

            if (tagPath != null) {
                return BuildArticleSummaryList(_tagService.FindTagByPath(tagPath),
                                                _tagService.TagPathRootSearch(tagPath));
            }

            return null;
        }

        public List<ArticleSummaryModel> BuildArticleSummaryList(TagModel tag, bool rootSearch)
        {
            List<ArticleSummaryModel> model =
                new List<ArticleSummaryModel>();

            if (tag != null)
            {
                var summaryModel = GetArticlesSummary();

                foreach (var articleSummary in summaryModel)
                {
                    ArticleTagModel articleTags = _tagService.GetTagsByArticleId(articleSummary.Id);


                    articleSummary.Path = tag.Path;


                    if (articleTags != null)
                    {
                        if (rootSearch)
                        {
                            if (articleTags.Tags.Any(x => x.Path.StartsWith(tag.Path)))
                            {
                                model.Add(articleSummary);
                            }
                        }
                        else
                        {
                            if (articleTags.Tags.Any(x => x.Path == tag.Path))
                            {
                                model.Add(articleSummary);
                            }
                        }
                    }
                }
            }

            return model.OrderByDescending(x => x.PublishDate).ToList();
        }

        public ArticleModel GetArticle(int id)
        {
            var model = JSONHelper.Deseriaize(Path, new List<ArticleModel>())
                .Where(x => x.Id == id).FirstOrDefault();
            UpdateViewCount(model);
            return model;
        }

        public void UpdateViewCount(ArticleModel article)
        {
            if (article != null && article.Id > 0)
            {
                var jArray = JSONHelper.CreateJArray(Path);

                int currentViewCount = jArray
                                        .FirstOrDefault(x => x["id"].Value<int>() == article.Id)["views"].Value<int>();

                int newViewCount = currentViewCount;
                newViewCount++;

                jArray.FirstOrDefault(x => x["id"].Value<int>() == article.Id)["views"] = newViewCount;

                JSONHelper.WriteToFile(Path, jArray);
            }
        }

        public int GetLatestArticleId()
        {
            var latestArticleId = GetArticles().OrderByDescending(x => x.Id).FirstOrDefault().Id;
            return latestArticleId;
        }
    }
}