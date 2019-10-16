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

namespace webApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlePublisherController : ControllerBase
    {
        private readonly IArticlePublisherService _articlePublisherService;

        public ArticlePublisherController(IArticlePublisherService articlePublisherService)
        {
            _articlePublisherService = articlePublisherService;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ArticlePublisherModel model)
        {
            _articlePublisherService.UpdateArticle(model);
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