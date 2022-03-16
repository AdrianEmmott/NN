using System;
using System.Collections.Generic;
using System.Linq;
using webApi.Models.Tags;
using webApi.ServiceInterfaces.Tags;

namespace webApi.Services.Articles.Tags
{
    public class TagPathService : ITagPathService
    {
        private readonly ITagParentService _tagParentService;

        public TagPathService(ITagParentService tagParentService)
        {
            _tagParentService = tagParentService;
        }

        public List<TagModel> SetPaths(List<TagModel> tags)
        {
            foreach (var tag in tags)
            {
                var tagId = tag.Id;
                var parentPath = SetPath(tags, tag);

                if(string.IsNullOrWhiteSpace(tag.Path))
                {
                    tag.Path = tag.Title.Replace(" ", "-");
                }

                tag.Path = $"{ parentPath }{ (!string.IsNullOrWhiteSpace(parentPath) ? "/" : "") }{ tag.Path }";
            }

            return tags;
        }

        private string SetPath(List<TagModel> tags, TagModel tag)
        {
            string path = "";

            var parentIds = _tagParentService.GetParentIds(tags, tag, new List<Guid>()).Distinct();
            
            var parentTags = tags.Where(x => parentIds.Contains(x.Id)).ToList();
            
            parentTags.Reverse();
            
            path = String.Join("/", parentTags.Select(x => x.Title.Replace(" ", "-")).ToArray());

            return path;
        }
    }
}