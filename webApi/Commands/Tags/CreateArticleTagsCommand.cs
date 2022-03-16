using MediatR;
using webApi.Models.Tags;

namespace webApi.Commands.Tags
{
    public class CreateArticleTagsCommand : IRequest
    {
        public CreateArticleTagsCommand(ArticleTagModel model) => ArticleTags = model;

        public ArticleTagModel ArticleTags { get; set; }
    }
}