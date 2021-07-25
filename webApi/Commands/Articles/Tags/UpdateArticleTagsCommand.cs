using MediatR;
using webApi.Models.Articles.Tags;

namespace webApi.Commands.Articles.Tags
{
    public class UpdateArticleTagsCommand : IRequest
    {
        public UpdateArticleTagsCommand(ArticleTagModel model) => ArticleTags = model;

        public ArticleTagModel ArticleTags { get; set; }
    }
}