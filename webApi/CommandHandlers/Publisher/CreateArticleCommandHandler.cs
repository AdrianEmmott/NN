// using Microsoft.VisualStudio.Text.UI.Commanding;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using webApi.Commands;
using webApi.Commands.Publisher;
using webApi.Contracts;
using webApi.Services;

namespace webApi.CommandHandlers.Publisher
{
    public class CreateArticleCommandHandler: IRequestHandler<CreateArticleCommand, int>
    {
        private readonly IArticlePublisherService _articlePublisherService;

        public CreateArticleCommandHandler(IArticlePublisherService articlePublisherService)
            => _articlePublisherService = articlePublisherService;

        public Task<int> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var articleId = _articlePublisherService.CreateArticle(request.Article);
            return Task.FromResult(articleId);
        }
    }
}