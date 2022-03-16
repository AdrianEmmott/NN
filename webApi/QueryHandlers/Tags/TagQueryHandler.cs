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

namespace webApi.QueryHandlers.Articles.Tags
{
    public class TagQueryHandler : IRequestHandler<GetTagQuery, TagModel>
    {
        private readonly ITagChildrenService _tagChildrenService;

        public TagQueryHandler(ITagChildrenService tagChildrenService)
        {
            _tagChildrenService = tagChildrenService;
        }

        public Task<TagModel> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var results = Task.FromResult(GetTag(request.tagId));
            
            return results;
        }

        private TagModel GetTag(Guid tagId)
        {
            using (var context = new NewsContext())
            {
                var results = context
                .Tags
                .Where(x => x.Id == tagId)
                .Select(x => new TagModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShowInNav = x.ShowInNav,
                    SortOrder = x.SortOrder,
                    Path = x.Title.Replace(" ", "-")
                })
                .FirstOrDefault();

                return results;
            }
        }
    }
}