using MediatR;
using webApi.Models;

namespace webApi.Commands.Publisher
{
    public class UpdateArticleCommand : IRequest
    {
        public UpdateArticleCommand(ArticlePublisherModel model) => Article = model;

        public ArticlePublisherModel Article { get; set; }
    }
}