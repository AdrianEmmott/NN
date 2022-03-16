using System.Collections.Generic;
using System.Linq;
using webApi.Models.Tags;

public static class TagListExtensions
{
    public static List<TagModel> Order(List<TagModel> tags)
    {
        tags = tags.OrderBy(x => x.SortOrder).ToList();

        return tags;
    }
}