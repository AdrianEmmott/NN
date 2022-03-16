using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using webApi.Models.SiteSettings;

namespace webApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected SiteSettingsModel SiteSettings;

        protected IWebHostEnvironment WebHostEnvironment;

        public BaseController(IOptions<SiteSettingsModel> siteSettings,
        IWebHostEnvironment webHostEnvironment)
        {
            SiteSettings = siteSettings.Value;
            WebHostEnvironment = webHostEnvironment;
        }
    }
}