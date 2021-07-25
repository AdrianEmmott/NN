// using Microsoft.VisualStudio.Text.UI.Commanding;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using webApi.Commands;
using webApi.Commands.Articles.Publisher;
using webApi.Contracts.Articles.Publisher;
using webApi.Services.Articles.Publisher;

namespace webApi.CommandHandlers.Articles.Publisher
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand>
    {
        private readonly IArticlePublisherService _articlePublisherService;

        public UpdateArticleCommandHandler(IArticlePublisherService articlePublisherService)
            => _articlePublisherService = articlePublisherService;

        public Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            _articlePublisherService.UpdateArticle(request.Article);
            return Task.FromResult(Unit.Value);
        }
    }
}