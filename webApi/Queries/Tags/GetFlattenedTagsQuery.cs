using MediatR;
using System.Collections.Generic;
using webApi.Models.Tags;

namespace webApi.Queries.Tags
{
    public record GetFlattenedTagsQuery():IRequest<List<TagModel>>;
}