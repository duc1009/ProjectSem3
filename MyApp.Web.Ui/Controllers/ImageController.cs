using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MyApp.Web.Ui.Controllers
{
    public class ImageController : Controller
    {
        private IHostingEnvironment environment;

        public ImageController(IHostingEnvironment environment)
        {
           this.environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> upload()
        //{
        //    //var name = data["file"];
        //    //[FromQuery] string sohoadon, [FromQuery] string userid
        //    string uploadFolder = _environment.WebRootPath;

        //    string hoaDonFolder = Path.Combine(uploadFolder, "123");
        //    if (!Directory.Exists(Path.GetDirectoryName(hoaDonFolder)))
        //        Directory.CreateDirectory(Path.GetDirectoryName(hoaDonFolder));

        //    string userFolder = Path.Combine(hoaDonFolder, "456");
        //    if (!Directory.Exists(Path.GetDirectoryName(userFolder)))
        //        Directory.CreateDirectory(Path.GetDirectoryName(userFolder));

        //    //foreach (IFormFile formFile in formFiles)
        //    //{
        //    //    string filename = Guid.NewGuid().ToString() + "_" + formFile.FileName;
        //    //    using (var stream = new FileStream(filename, FileMode.Create))
        //    //    {
        //    //        await formFile.CopyToAsync(stream);
        //    //    }
        //    //}

        //    //string filename = Guid.NewGuid().ToString() + "_" + formFile.FileName;
        //    //using (var stream = new FileStream(filename, FileMode.Create))
        //    //{
        //    //    await formFile.CopyToAsync(stream);
        //    //}

        //    return Ok();
        //}

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult UploadFilesAjax(IList<IFormFile> filess)
        {

            long size = 0;
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                var filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                filename = environment.WebRootPath + $@"\{filename}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }

            string message = "ok";
            return Json(message);
        }

    }
}
