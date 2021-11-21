using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using S3.Services;
using S3_AWS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace S3_AWS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IS3Service _s3Service;
        public HomeController(ILogger<HomeController> logger,IS3Service s3Service)
        {
            _logger = logger;
            _s3Service = s3Service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            //process file code....
            await using var newMemoryStream = new MemoryStream();
            await file.CopyToAsync(newMemoryStream);

            var fileExtension = Path.GetExtension(file.FileName);
            var documentName = $"{Guid.NewGuid()}{fileExtension}";

            var document = new S3.Models.S3Document()
            {
                Key= documentName,
                InputStream= newMemoryStream
            };
            //call se transfer utility 
          var result= await _s3Service.UploadFiletoS3BucketAsync(document);
            ViewBag.result = result.Message; 
            //add record in db 

            return View();
        }

    }
}
