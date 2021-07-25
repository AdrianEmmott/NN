// using Microsoft.VisualStudio.Text.UI.Commanding;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using webApi.Commands;
using webApi.Commands.Articles.Publisher;
using webApi.Commands.Articles.Tags;
using webApi.Contracts.Articles.Publisher;
using webApi.Contracts.Articles.Tags;
using webApi.Services.Articles.Publisher;

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