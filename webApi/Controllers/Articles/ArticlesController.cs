using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using webApi.Models.Articles;
using webApi.Contracts.Articles;
using webApi.Services.Articles;
using webApi.Models.SiteSettings;

namespace webApi.Controllers.Articles
{
    [EnableCors("MyPolicy")]
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : BaseController
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService,
            IOptions<SiteSettingsModel> siteSettings,
            IWebHostEnvironment webHostEnvironment)
            : base(siteSettings, webHostEnvironment)
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
            var httpRequest = HttpContext.Request.Host.Value;

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