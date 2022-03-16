using MediatR;
using System;
using webApi.Models.Articles;

namespace webApi.Queries
{
    public record GetArticleQuery(Guid articleId) : IRequest<ArticleModel>;
}