using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using webApi.Models.Tags;
using webApi.Queries.Tags;
using System.Linq;
using webApi.Data.Entities;
using webApi.ServiceInterfaces.Tags;

namespace webApi.QueryHandlers.Articles.Tags
{
    public class TreeTagsQueryHandler : IRequestHandler<GetTreeTagsQuery, List<TagModel>>
    {
        private readonly ITagChildrenService _tagChildrenService;

        public TreeTagsQueryHandler(ITagChildrenService tagChildrenService)
        {
            _tagChildrenService = tagChildrenService;
        }

        public Task<List<TagModel>> Handle(GetTreeTagsQuery request, CancellationToken cancellationToken)
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
                .Where(x => x.ParentId == null)
                .Select(x => new TagModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShowInNav = x.ShowInNav,
                    SortOrder = x.SortOrder,
                    Path = x.Title.Replace(" ", "-")
                })
                .ToList();

                results = _tagChildrenService.GetChildren(results);

                results = TagListExtensions.Order(results);

                return results;
            }
        }
    }
}