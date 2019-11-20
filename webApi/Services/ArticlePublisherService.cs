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
    public class ArticlePublisherService : IArticlePublisherService
    {
        private const string Path = "Data/articles.json";
        private readonly IArticleService _articleService;

        public ArticlePublisherService(IArticleService articleService) => _articleService = articleService;

        public int CreateArticle(ArticlePublisherModel model)
        {
            model.Id = GetNextArticleId();
            JSONHelper.CreateJSONElement(Path, model);
            return model.Id;
        }

        public void UpdateArticle(ArticlePublisherModel model)
        {
            JSONHelper.UpdateJSONElement(Path, "id", model, model.Id);
        }

        public int GetNextArticleId()
        {
            var nextArticleId = _articleService.GetLatestArticleId() + 1;
            return nextArticleId;
        }
    }
}