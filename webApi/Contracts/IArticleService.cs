using System.Collections.Generic;
using webApi.Models;

namespace webApi.Contracts
{
    public interface IArticleService
    {
        ArticleModel GetArticle(int id);
        List<ArticleModel> GetArticles();
        List<ArticleModelSummary> GetArticlesSummary();

        List<ArticleModelSummary> GetArticlesSummaryByTagPath(string tagPath);
        void UpdateViewCount(int id);
    }
}