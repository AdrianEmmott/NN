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
    public class TagQueryByPathHandler : IRequestHandler<GetTagByPathQuery, TagModel>
    {
        private readonly ITagPathService _tagPathService;

        public TagQueryByPathHandler(ITagPathService tagPathService)
        {
            _tagPathService = tagPathService;
        }

        public Task<TagModel> Handle(GetTagByPathQuery request, CancellationToken cancellationToken)
        {
            var results = Task.FromResult(GetTag(request.path));
            
            return results;
        }

        private TagModel GetTag(string path)
        {
            using (var context = new NewsContext())
            {
                var results = context
                .Tags
                .Select(x => new TagModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShowInNav = x.ShowInNav,
                    SortOrder = x.SortOrder,
                    Path = x.Title.Replace(" ", "-")
                })
                .ToList();

                results = _tagPathService.SetPaths(results);

                return results.FirstOrDefault(x => x.Path == path);
            }
        }
    }
}