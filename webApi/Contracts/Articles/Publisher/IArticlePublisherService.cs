using System.Collections.Generic;
using webApi.Models.Articles.Publisher;

namespace webApi.Contracts.Articles.Publisher
{
    public interface IArticlePublisherService
    {
        int CreateArticle(ArticlePublisherModel model);
        
        void UpdateArticle(ArticlePublisherModel model);

        int GetNextArticleId();
    }
}