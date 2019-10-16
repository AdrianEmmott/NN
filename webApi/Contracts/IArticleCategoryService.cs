using System.Collections.Generic;
using webApi.Models;

namespace webApi.Contracts
{
    public interface IArticleCategoryService
    {
        List<ArticleCategoryModel> GetArticleCategories();
    }
}