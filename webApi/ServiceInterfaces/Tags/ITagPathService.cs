using System.Collections.Generic;
using webApi.Models.Tags;

namespace webApi.ServiceInterfaces.Tags
{
    public interface ITagPathService
    {
        List<TagModel> SetPaths(List<TagModel> tags);
    }
}