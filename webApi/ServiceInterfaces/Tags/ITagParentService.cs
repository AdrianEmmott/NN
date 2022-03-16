using System;
using System.Collections.Generic;
using webApi.Models.Tags;

namespace webApi.ServiceInterfaces.Tags
{
    public interface ITagParentService
    {
        List<Guid> GetParentIds(List<TagModel> tags, TagModel tag, List<Guid> parentIds);
    }
}