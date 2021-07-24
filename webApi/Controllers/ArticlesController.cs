using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Contracts;
using webApi.Services;
//using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using webApi.Models.SiteSettings;

namespace webApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : BaseController
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService,
            IOptions<SiteSettingsModel> siteSettings)
            : base(siteSettings) 
            => _articleService = articleService;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ArticleModel>> Get()
        {
            return _articleService.GetArticles();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var xxx = base.SiteSettings;

            var model = _articleService.GetArticle(id);
            return Ok(model);
        }

        // GET api/articles/summary
        [HttpGet("summary")]
        public ActionResult GetArticlesSummary(int id)
        {
            var model = _articleService.GetArticlesSummary();
            return Ok(model);
        }

        [HttpGet("summary/tagpaths")]
        public ActionResult GetArticlesSummaryByTagPath([FromQuery(Name = "tags")] string tags)
        {
            var model = _articleService.GetArticlesSummaryByTagPath(tags);
            return Ok(model);
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