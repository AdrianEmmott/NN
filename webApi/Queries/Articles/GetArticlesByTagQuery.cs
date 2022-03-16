using MediatR;
using System;
using System.Collections.Generic;
using webApi.Models.Articles;

namespace webApi.Queries
{
    public record GetArticlesByTagQuery(Guid tagId) : IRequest<List<ArticleModel>>;
}