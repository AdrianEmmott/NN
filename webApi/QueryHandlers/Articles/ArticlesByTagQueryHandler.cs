using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using webApi.Data.Entities;
using webApi.Models.Articles;
using webApi.Queries;

namespace webApi.QueryHandlers.Articles
{
    public class ArticleByTagQueryHandler : IRequestHandler<GetArticlesByTagQuery, List<ArticleModel>>
    {
        public Task<List<ArticleModel>> Handle(GetArticlesByTagQuery request, CancellationToken cancellationToken) 
        {
            var results = Task.FromResult(GetArticlesByTag(request.tagId));
            
            return results;
        }

        private List<ArticleModel> GetArticlesByTag(Guid tagId)
        {
            using (var context = new NewsContext())
            {
                var results = context
                .Articles
                .Include(x => x.ArticleTags)
                .Where(x => x.ArticleTags.Any(y => y.TagId == tagId))
                .Select(x => ArticleQueryHandlersHelper.SetModel(x))
                .ToList();

                return results;
            }
        }
    }
}