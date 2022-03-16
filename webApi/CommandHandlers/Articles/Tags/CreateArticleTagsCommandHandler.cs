using MediatR;
using System.Threading;
using System.Threading.Tasks;
using webApi.Commands.Tags;

namespace webApi.CommandHandlers.Publisher
{
    public class CreateArticleTagsCommandHandler : IRequestHandler<CreateArticleTagsCommand>
    {
        public Task<Unit> Handle(CreateArticleTagsCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}