using MediatR;
using System;
using webApi.Models.Tags;

namespace webApi.Queries.Tags
{
    public record GetTagQuery(Guid tagId):IRequest<TagModel>;
}