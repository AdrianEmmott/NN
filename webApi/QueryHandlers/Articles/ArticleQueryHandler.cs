using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using webApi.Data.Entities;
using webApi.Models.Articles;
using webApi.Queries;

namespace webApi.QueryHandlers.Articles
{
    public class ArticleQueryHandler : IRequestHandler<GetArticleQuery, ArticleModel>
    {
        public Task<ArticleModel> Handle(GetArticleQuery request, CancellationToken cancellationToken) 
        {
            var results = Task.FromResult(GetArticle(request.articleId));
            
            return results;
        }

        private ArticleModel GetArticle(Guid articleId)
        {
            using (var context = new NewsContext())
            {
                var results = context
                .Articles
                .Where(x => x.Id == articleId)
                .Select(x => ArticleQueryHandlersHelper.SetModel(x))
                .FirstOrDefault();

                return results;
            }
        }
    }
}