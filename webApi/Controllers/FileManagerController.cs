using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using System.IO;
using System.Threading;
using System.Web;

using webApi.Models.SiteSettings;

namespace webApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/file-manager")]
    public class FileManagerController : BaseController
    {
        public FileManagerController(IOptions<SiteSettingsModel> siteSettings,
        IWebHostEnvironment webHostEnvironment)
        : base(siteSettings, webHostEnvironment) { }

        [HttpGet("download/{fileType}")]
        public IActionResult Get(string fileType, [FromQuery] string link)
        {
            var filePath = fileType.Equals("image")
            ? base.SiteSettings.Uploads.FilePath
            : base.SiteSettings.Uploads.ImagePath;

            string webRootPath = Path.Combine(WebHostEnvironment.WebRootPath, filePath);
            var filename = link.Substring(link.LastIndexOf('/') + 1);

            var net = new System.Net.WebClient();
            var data = net.DownloadData(webRootPath + "\\" + filename);
            var content = new System.IO.MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";

            return File(content, contentType, filename);
        }

        [HttpPost("upload/{fileType}")]
        public IActionResult Post(string fileType)
        {
            try
            {
                var httpRequest = HttpContext.Request;

                var uploadPath = fileType.Equals("image")
                ? base.SiteSettings.Uploads.ImagePath
                : base.SiteSettings.Uploads.FilePath;

                if (httpRequest.Form.Files.Count > 0)
                {
                    var docfiles = new List<string>();
                    foreach (var file in httpRequest.Form.Files)
                    {
                        var postedFile = httpRequest.Form.Files[0];

                        string formattedFilename = postedFile.FileName.Replace(" ", "");

                        string webRootPath = Path.Combine(WebHostEnvironment.WebRootPath, uploadPath);
                        string contentRootPath = WebHostEnvironment.ContentRootPath;
                        string path = "";

                        if (string.IsNullOrWhiteSpace(WebHostEnvironment.WebRootPath))
                        {
                            path = Path.Combine(Directory.GetCurrentDirectory(), uploadPath);
                        }

                        using (FileStream output = System.IO.File.Create($"{webRootPath}/{formattedFilename}"))
                        {
                            file.CopyTo(output);
                        }

                        var returnedFilename = $"http://localhost:8090/wwwroot/{uploadPath}/{formattedFilename}";

                        return Ok(new { url = returnedFilename });
                    }
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}