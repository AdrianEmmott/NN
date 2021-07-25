using MediatR;
using webApi.Models.Articles.Publisher;

namespace webApi.Commands.Articles.Publisher
{
    public class UpdateArticleCommand : IRequest
    {
        public UpdateArticleCommand(ArticlePublisherModel model) => Article = model;

        public ArticlePublisherModel Article { get; set; }
    }
}