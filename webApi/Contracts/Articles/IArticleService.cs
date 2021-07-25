using System.Collections.Generic;
using webApi.Models.Articles;

namespace webApi.Contracts.Articles
{
    public interface IArticleService
    {
        ArticleModel GetArticle(int id);
        
        List<ArticleModel> GetArticles();
        
        List<ArticleSummaryModel> GetArticlesSummary();
        
        List<ArticleSummaryModel> GetArticlesSummaryByTagPath(string tagPath);
        
        void UpdateViewCount(ArticleModel article);
        
        int GetLatestArticleId();
    }
}