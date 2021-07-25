using MediatR;
using webApi.Models.Articles.Publisher;

namespace webApi.Commands.Articles.Publisher
{
    public class CreateArticleCommand : IRequest<int>
    {
        public CreateArticleCommand(ArticlePublisherModel model) => Article = model;

        public ArticlePublisherModel Article { get; set; }
    }
}