using MediatR;
using webApi.Models.Tags;

namespace webApi.Queries.Tags
{
    public record GetTagByPathQuery(string path):IRequest<TagModel>;
}