using webApi.Data.Entities;
using webApi.Models.Articles;

namespace webApi.Data.Interfaces.Articles
{
    public interface IBaseArticlesRepository
    {
        ArticleModel SetModel(Article x);
    }
}