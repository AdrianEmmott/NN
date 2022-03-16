using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using webApi.Models.Tags;
using webApi.Queries.Tags;
using webApi.Data.Entities;
using webApi.ServiceInterfaces.Tags;

namespace webApi.QueryHandlers.Articles.Tags
{
    public class FlattenedTagsQueryHandler : IRequestHandler<GetFlattenedTagsQuery, List<TagModel>>
    {
        private readonly ITagPathService _tagPathService;

        public FlattenedTagsQueryHandler(ITagPathService tagPathService)
        {
            _tagPathService = tagPathService;
        }

        public Task<List<TagModel>> Handle(GetFlattenedTagsQuery request, CancellationToken cancellationToken)
        {
            var results = Task.FromResult(GetTags());
            
            return results;
        }

        private List<TagModel> GetTags()
        {
            using (var context = new NewsContext())
            {
                var results = context
                .Tags
                .Select(x => new TagModel
                {
                    Id = x.Id,
                    ParentId = x.ParentId,
                    Title = x.Title,
                    ShowInNav = x.ShowInNav,
                    SortOrder = x.SortOrder,
                    Path = x.Title.Replace(" ", "-")
                })
                .ToList();

                results = TagListExtensions.Order(results);

                results = _tagPathService.SetPaths(results);

                return results;
            }
        }
    }
}