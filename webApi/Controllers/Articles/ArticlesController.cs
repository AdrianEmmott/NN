using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using webApi.Models.Articles;
using webApi.Contracts.Articles;

using webApi.Models.SiteSettings;
using MediatR;
using webApi.Queries;
using System;
using webApi.Queries.Tags;

namespace webApi.Controllers.Articles
{
    [EnableCors("MyPolicy")]
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : BaseController
    {
        private readonly IMediator _mediator;
        //private readonly IArticleService _articleService;

        public ArticlesController(//IArticleService articleService,
            IMediator mediator,
            IOptions<SiteSettingsModel> siteSettings,
            IWebHostEnvironment webHostEnvironment)
            : base(siteSettings, webHostEnvironment)
            => _mediator = mediator;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ArticleModel>> Get()
        {
            return null;
            //return _articleService.GetArticles();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var model = _mediator.Send(new GetArticleQuery(id));

            return Ok(model.Result);
        }

        // GET api/articles/summary
        [HttpGet("summary")]
        public ActionResult GetArticlesSummary()
        {
            return null;
            //var model = _articleService.GetArticlesSummary();
            //return Ok(model);
        }

        [HttpGet("summary/{tagId}")]
        public ActionResult GetArticlesSummaryByTagPath(Guid tagId)
        {
            var model = _mediator.Send(new GetArticlesByTagQuery(tagId));

            return Ok(model.Result);
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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