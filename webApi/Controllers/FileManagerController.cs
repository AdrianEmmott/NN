using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;

using System.Web;
using System.IO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

[EnableCors("MyPolicy")]
[Route("api/file-manager")]

public class FileManagerController : Controller
{
    const string IMAGEUPLOADPATH = @"uploads/images";

    const string FILEUPLOADPATH = @"uploads/files";

    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileManagerController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet("download/{fileType}")]
    public IActionResult Get(string fileType, [FromQuery]string link)
    {
        var filePath  = fileType.Equals("image") ? IMAGEUPLOADPATH : FILEUPLOADPATH;
        string webRootPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);
        var filename = link.Substring(link.LastIndexOf('/') +1 );

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

            var uploadPath = fileType.Equals("image") ? IMAGEUPLOADPATH : FILEUPLOADPATH;

            if (httpRequest.Form.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (var file in httpRequest.Form.Files)
                {
                    var postedFile = httpRequest.Form.Files[0];

                    string formattedFilename = postedFile.FileName.Replace(" ", "");

                    string webRootPath = Path.Combine(_webHostEnvironment.WebRootPath, uploadPath);
                    string contentRootPath = _webHostEnvironment.ContentRootPath;
                    string path = "";

                    if (string.IsNullOrWhiteSpace(_webHostEnvironment.WebRootPath))
                    {
                        path = Path.Combine(Directory.GetCurrentDirectory(), uploadPath);
                    }

                    using (FileStream output = System.IO.File.Create($"{webRootPath}/{formattedFilename}"))
                    {
                        file.CopyTo(output);
                    }
                    
                    var returnedFilename = $"http://localhost:8090/wwwroot/{uploadPath}/{formattedFilename}" ;

                    return Ok(new {url = returnedFilename});
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