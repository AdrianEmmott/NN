using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using webApi.Models.Articles.Tags;
using webApi.Contracts.Articles.Tags;
using webApi.Services.Articles.Tags;
using webApi.CommandHandlers.Articles;
using webApi.Commands.Articles.Tags;

namespace webApi.Controllers.Articles.Tags
{
    [EnableCors("MyPolicy")]
    [Route("api/articles/tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IMediator _mediator;

        public TagsController(ITagService tagService,
                              IMediator mediator)
        {
            _tagService = tagService;
            _mediator = mediator;
        }

        [HttpGet("all/flattened")]
        public ActionResult GetAllTagsFlattened()
        {
            var model = _tagService.GetFlattenedTags(null);
            return Ok(model);
        }

        [HttpGet("all/tree")]
        public ActionResult GetAllTags()
        {
             var model = _tagService.GetAllTags();
             return Ok(model); 
        }

        [HttpGet("article/{id}")]
        public ActionResult GetTagsByArticleId(int id)
        {
             var model = _tagService.GetTagsByArticleId(id);
             return Ok(model); 
        }

        [HttpPost("create-article-tags")]
        public ActionResult CreateTagsByArticleId(ArticleTagModel model)
        {
            _mediator.Send(new CreateArticleTagsCommand(model));
            return Ok();
        }

        [HttpPost("update-article-tags")]
        public ActionResult UpdateTagsByArticleId(ArticleTagModel model) 
        //public ActionResult UpdateTagsByArticleId(string test) 
        {            
            _tagService.UpdateArticleTags(model);
            return Ok();
        }
    }
}