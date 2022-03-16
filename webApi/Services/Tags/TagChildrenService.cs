using System;
using System.Collections.Generic;
using System.Linq;
using webApi.Data.Entities;
using webApi.Models.Tags;
using webApi.ServiceInterfaces.Tags;

namespace webApi.Services.Tags
{
    public class TagChildrenService : ITagChildrenService
    {
        private readonly ITagPathService _tagPathService;

        public TagChildrenService(ITagPathService tagPathService)
        {
            _tagPathService = tagPathService;
        }

        public List<TagModel> GetChildren(List<TagModel> tags)
        {
            foreach (var tag in tags)
            {
                tag.Tags = GetChildrenInner(tag.Id, tag.Title.Replace(" ", "-"));
            }

            return tags;
        }

        private List<TagModel> GetChildrenInner(Guid id, string parentPath)
        {

            using (var context = new NewsContext())
            {
                var results = context
                .Tags
                .Where(x => x.ParentId == id)
                .Select(x => new TagModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShowInNav = x.ShowInNav,
                    SortOrder = x.SortOrder
                })
                .ToList();

                results = GetChildren(results);

                results = _tagPathService.SetPaths(results);

                results = TagListExtensions.Order(results);

                return results;
            }
        }
    }
}