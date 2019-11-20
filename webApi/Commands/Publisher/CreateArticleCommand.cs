using MediatR;
using webApi.Models;

namespace webApi.Commands.Publisher
{
    public class CreateArticleCommand : IRequest<int>
    {
        public CreateArticleCommand(ArticlePublisherModel model) => Article = model;

        public ArticlePublisherModel Article { get; set; }
    }
}