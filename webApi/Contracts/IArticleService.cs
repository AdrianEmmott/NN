using System.Collections.Generic;
using webApi.Models;

namespace webApi.Contracts
{
    public interface IArticleService
    {
        ArticleModel GetArticle(int id);
        List<ArticleModel> GetArticles();
        List<ArticleModelSummary> GetArticlesSummary();
        void UpdateViewCount(int id);
    }
}