using MediatR;
using webApi.Models.Articles.Tags;

namespace webApi.Commands.Articles.Tags
{
    public class CreateArticleTagsCommand : IRequest
    {
        public CreateArticleTagsCommand(ArticleTagModel model) => ArticleTags = model;

        public ArticleTagModel ArticleTags { get; set; }
    }
}