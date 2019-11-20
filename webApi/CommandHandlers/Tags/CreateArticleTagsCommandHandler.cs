// using Microsoft.VisualStudio.Text.UI.Commanding;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using webApi.Commands;
using webApi.Commands.Publisher;
using webApi.Commands.Tags;
using webApi.Contracts;
using webApi.Services;

namespace webApi.CommandHandlers.Publisher
{
    public class CreateArticleTagsCommandHandler : IRequestHandler<CreateArticleTagsCommand>
    {
        private readonly ITagService _tagService;

        public CreateArticleTagsCommandHandler(ITagService tagService) 
            => _tagService = tagService;
        
        public Task<Unit> Handle(CreateArticleTagsCommand request, CancellationToken cancellationToken)
        {
            _tagService.CreateArticleTags(request.ArticleTags);
            return Task.FromResult(Unit.Value);
        }
    }
}