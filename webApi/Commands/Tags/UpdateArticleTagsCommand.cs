using System.Collections.Generic;
using MediatR;
using webApi.Models.Tags;

namespace webApi.Commands.Tags
{
    public class UpdateArticleTagsCommand : IRequest
    {
        public UpdateArticleTagsCommand(List<ArticleTagModel> model) => ArticleTags = model;

        public List<ArticleTagModel> ArticleTags { get; set; }
    }
}