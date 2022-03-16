// using Microsoft.VisualStudio.Text.UI.Commanding;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using webApi.Commands.Articles.Publisher;
using webApi.Contracts.Articles.Publisher;

namespace webApi.CommandHandlers.Articles.Publisher
{
    public class CreateArticleCommandHandler: IRequestHandler<CreateArticleCommand, int>
    {
        //private readonly IArticlePublisherService _articlePublisherService;

        //public CreateArticleCommandHandler(IArticlePublisherService articlePublisherService)
          //  => _articlePublisherService = articlePublisherService;

        public Task<int> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            return null;
            //var articleId = _articlePublisherService.CreateArticle(request.Article);
            //return Task.FromResult(articleId);
        }
    }
}