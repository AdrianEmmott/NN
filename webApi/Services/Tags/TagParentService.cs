using System;
using System.Collections.Generic;
using System.Linq;
using webApi.Models.Tags;
using webApi.ServiceInterfaces.Tags;

namespace webApi.Services.Tags
{
    public class TagParentService : ITagParentService
    {
        public List<Guid> GetParentIds(List<TagModel> tags, TagModel tag, List<Guid> parentIds)
        {
            if(tag.ParentId.HasValue)
            {
                var parentTag = tags.FirstOrDefault(x => x.Id == tag.ParentId);

                if(!parentIds.Any(x => x == parentTag.Id))
                {
                    parentIds.Add(parentTag.Id);
                }

                GetParentIds(tags, parentTag, parentIds);
            }

            return parentIds;
        }
    }
}