using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using webApi.Models.Tags;
using webApi.Queries.Tags;
using System.Linq;
using webApi.Data.Entities;
using webApi.ServiceInterfaces.Tags;
using System;
using Microsoft.EntityFrameworkCore;

namespace webApi.QueryHandlers.Articles.Tags
{
    public class TagsByArticleQueryHandler : IRequestHandler<GetTagsByArticleQuery, List<TagModel>>
    {
        private readonly ITagPathService _tagPathService;

        public TagsByArticleQueryHandler(ITagPathService tagPathService)
        {
            _tagPathService = tagPathService;
        }

        public Task<List<TagModel>> Handle(GetTagsByArticleQuery request, CancellationToken cancellationToken)
        {
            var results = Task.FromResult(GetTags(request.articleId));
            
            return results;
        }

        private List<TagModel> GetTags(Guid articleId)
        {
            using (var context = new NewsContext())
            {
                var results = context
                .Tags
                .Include(x => x.ArticleTags)
                .Where(x => x.ArticleTags.Any(x => x.ArticleId == articleId))
                .Select(x => new TagModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShowInNav = x.ShowInNav,
                    SortOrder = x.SortOrder,
                    
                })
                .ToList();

                results = _tagPathService.SetPaths(results);

                results = TagListExtensions.Order(results);

                return results;
            }
        }
    }
}