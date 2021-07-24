using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Contracts;
using webApi.Services;
using Microsoft.Extensions.Configuration;
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

        public BaseController(IOptions<SiteSettingsModel> siteSettings)
        {
            SiteSettings = siteSettings.Value;
        }
    }
}