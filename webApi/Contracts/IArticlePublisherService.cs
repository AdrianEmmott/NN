using System.Collections.Generic;
using webApi.Models;

namespace webApi.Contracts
{
    public interface IArticlePublisherService
    {
        void CreateArticle(ArticlePublisherModel model);
        void UpdateArticle(ArticlePublisherModel model);
    }
}