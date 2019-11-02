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
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet("all")]
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

        [HttpPost("article/update")]
        public ActionResult UpdateTagsByArticleId(ArticleTagModel model) 
        {
            _tagService.UpdateArticleTags(model);
            return Ok();
        }
    }
}