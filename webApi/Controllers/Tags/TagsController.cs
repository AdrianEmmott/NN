using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using webApi.Commands.Tags;
using webApi.Queries.Tags;
using System;
using webApi.Models.Tags;
using System.Collections.Generic;
using System.Linq;

namespace webApi.Controllers.Tags
{
    [EnableCors("MyPolicy")]
    [Route("api/tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("path/{path}")]
        public ActionResult GetTagByPath(string path)
        {
            var model = _mediator.Send(new GetTagByPathQuery(path));

            return Ok(model.Result);
        }

        [HttpGet("all/flattened")]
        public ActionResult GetAllTagsFlattened()
        {
            var model = _mediator.Send(new GetFlattenedTagsQuery());

            return Ok(model.Result);
        }

        [HttpGet("all/tree")]
        public ActionResult GetAllTagsTree()
        {
             var model = _mediator.Send(new GetTreeTagsQuery());

             return Ok(model.Result);
        }

        [HttpGet("article/{id}")]
        public ActionResult GetTagsByArticleId(Guid id)
        {
            var model = _mediator.Send(new GetTagsByArticleQuery(id));

            return Ok(model.Result);
        }

        [HttpPost("create-article-tags")]
        public ActionResult CreateTagsByArticleId(ArticleTagModel model)
        {
            _mediator.Send(new CreateArticleTagsCommand(model));

            return Ok();
        }

        [HttpPost("update-article-tags")]
        public ActionResult UpdateTagsByArticleId(List<ArticleTagModel> model) 
        {
            try 
            {
                _mediator.Send(new UpdateArticleTagsCommand(model));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            

            return Ok();
        }
    }
}