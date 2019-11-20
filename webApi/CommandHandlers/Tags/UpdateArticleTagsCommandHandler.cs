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
    public class UpdateArticleTagsCommandHandler : IRequestHandler<UpdateArticleTagsCommand>
    {
        private readonly ITagService _tagService;

        public UpdateArticleTagsCommandHandler(ITagService tagService) 
            => _tagService = tagService;
        
        public Task<Unit> Handle(UpdateArticleTagsCommand request, CancellationToken cancellationToken)
        {
            _tagService.UpdateArticleTags(request.ArticleTags);
            return Task.FromResult(Unit.Value);
        }
    }
}