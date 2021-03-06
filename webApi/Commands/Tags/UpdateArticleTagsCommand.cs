using MediatR;
using webApi.Models;

namespace webApi.Commands.Tags
{
    public class UpdateArticleTagsCommand : IRequest
    {
        public UpdateArticleTagsCommand(ArticleTagModel model) => ArticleTags = model;

        public ArticleTagModel ArticleTags { get; set; }
    }
}