using MediatR;
using webApi.Models;

namespace webApi.Commands.Tags
{
    public class CreateArticleTagsCommand : IRequest
    {
        public CreateArticleTagsCommand(ArticleTagModel model) => ArticleTags = model;

        public ArticleTagModel ArticleTags { get; set; }
    }
}