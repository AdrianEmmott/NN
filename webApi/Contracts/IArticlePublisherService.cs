using System.Collections.Generic;
using webApi.Models;

namespace webApi.Contracts
{
    public interface IArticlePublisherService
    {
        int CreateArticle(ArticlePublisherModel model);
        
        void UpdateArticle(ArticlePublisherModel model);

        int GetNextArticleId();
    }
}