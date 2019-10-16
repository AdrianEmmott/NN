using webApi.Commands;
using webApi.Contracts;
using webApi.Services;

namespace webApi.CommandHandlers
{
    public class ArticlePublisherCommandHandler
    {
        private readonly IArticlePublisherService _articlePublisherService;

        public ArticlePublisherCommandHandler(IArticlePublisherService articlePublisherService)
        { 
            _articlePublisherService = articlePublisherService;
        }

        public void Handle(UpdateArticleCommand command)
        {

        }
    }
}