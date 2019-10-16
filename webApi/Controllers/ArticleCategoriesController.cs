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
    public class ArticleCategoriesController : ControllerBase
    {
        private readonly IArticleCategoryService _articleCategoryService;

        public ArticleCategoriesController(IArticleCategoryService articleCategoryService)
        {
            _articleCategoryService = articleCategoryService;
        }


        [HttpGet("categories")]
        public ActionResult GetArticleCategories(int id)
        {
             var model = _articleCategoryService.GetArticleCategories();
             return Ok(model); 
        }
    }
}