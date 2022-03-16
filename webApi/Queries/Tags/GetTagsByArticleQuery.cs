using MediatR;
using System;
using System.Collections.Generic;
using webApi.Models.Tags;

namespace webApi.Queries.Tags
{
    public record GetTagsByArticleQuery(Guid articleId):IRequest<List<TagModel>>;
}