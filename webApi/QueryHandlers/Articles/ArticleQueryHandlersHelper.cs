using webApi.Data.Entities;
using webApi.Models.Articles;

namespace webApi.QueryHandlers.Articles
{
    public class ArticleQueryHandlersHelper
    {
        public static ArticleModel SetModel(Article x)
        {
            var model = new ArticleModel
            {
                Id = x.Id,
                Title = x.Title,
                SubTitle = x.SubTitle,
                Summary = x.Summary,
                HeaderImage = x.HeaderImage,
                Content = x.Content,
                Author = x.Author,
                Published = x.Published ?? false,
                PublishDate = x.PublishDate ?? null,
                Views = x.Views ?? null
            };

            return model;
        }
    }
}