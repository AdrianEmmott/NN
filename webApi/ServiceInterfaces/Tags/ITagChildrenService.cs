using System.Collections.Generic;
using webApi.Models.Tags;

namespace webApi.ServiceInterfaces.Tags
{
    public interface ITagChildrenService
    {
        List<TagModel> GetChildren(List<TagModel> tags);
    }
}