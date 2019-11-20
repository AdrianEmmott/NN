using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Contracts;
using webApi.Services;
using webApi.CommandHandlers;
using MediatR;
using webApi.Commands.Publisher;

namespace webApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IArticlePublisherService _articlePublisherService;
        private readonly IMediator _mediator;

        public PublisherController(IArticlePublisherService articlePublisherService
                                        , IMediator mediator)
             => (_articlePublisherService, _mediator) = (articlePublisherService, mediator);

        [HttpPost("update-article")]
        public void UpdateArticle(ArticlePublisherModel model)
        {
            _mediator.Send(new UpdateArticleCommand(model));
        }

        [HttpPost("create-article")]
        public ActionResult CreateArticle(ArticlePublisherModel model)
        {
            var result = _mediator.Send(new CreateArticleCommand(model));
            return Ok(result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}