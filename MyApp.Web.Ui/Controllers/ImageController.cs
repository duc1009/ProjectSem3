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
        private IHostingEnvironment _environment;

        public ImageController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> upload(IFormFile imageFile)
        {
            //var name = data["file"];
            //[FromQuery] string sohoadon, [FromQuery] string userid
            string uploadFolder = _environment.WebRootPath;

            string hoaDonFolder = Path.Combine(uploadFolder, "123");
            if (!Directory.Exists(Path.GetDirectoryName(hoaDonFolder)))
                Directory.CreateDirectory(Path.GetDirectoryName(hoaDonFolder));

            string userFolder = Path.Combine(hoaDonFolder, "456");
            if (!Directory.Exists(Path.GetDirectoryName(userFolder)))
                Directory.CreateDirectory(Path.GetDirectoryName(userFolder));

            //foreach (IFormFile formFile in formFiles)
            //{
            //    string filename = Guid.NewGuid().ToString() + "_" + formFile.FileName;
            //    using (var stream = new FileStream(filename, FileMode.Create))
            //    {
            //        await formFile.CopyToAsync(stream);
            //    }
            //}

            //string filename = Guid.NewGuid().ToString() + "_" + formFile.FileName;
            //using (var stream = new FileStream(filename, FileMode.Create))
            //{
            //    await formFile.CopyToAsync(stream);
            //}

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> upload2(List<IFormFile> imageFiles)
        {
            //var name = data["file"];
            //[FromQuery] string sohoadon, [FromQuery] string userid
            string uploadFolder = _environment.WebRootPath;

            string hoaDonFolder = Path.Combine(uploadFolder, "123");
            if (!Directory.Exists(Path.GetDirectoryName(hoaDonFolder)))
                Directory.CreateDirectory(Path.GetDirectoryName(hoaDonFolder));

            string userFolder = Path.Combine(hoaDonFolder, "456");
            if (!Directory.Exists(Path.GetDirectoryName(userFolder)))
                Directory.CreateDirectory(Path.GetDirectoryName(userFolder));

            //foreach (IFormFile formFile in formFiles)
            //{
            //    string filename = Guid.NewGuid().ToString() + "_" + formFile.FileName;
            //    using (var stream = new FileStream(filename, FileMode.Create))
            //    {
            //        await formFile.CopyToAsync(stream);
            //    }
            //}

            //string filename = Guid.NewGuid().ToString() + "_" + formFile.FileName;
            //using (var stream = new FileStream(filename, FileMode.Create))
            //{
            //    await formFile.CopyToAsync(stream);
            //}

            return Ok();
        }

        //[HttpPost]
        //public string Upload_File()

        //{

        //    string result = string.Empty;

        //    try

        //    {

        //        long size = 0;

        //        var file = Request.Form.Files;

        //        var filename = ContentDispositionHeaderValue

        //                        .Parse(file[0].ContentDisposition)

        //                        .FileName

        //                        .Trim('"');

        //        string FilePath = _environment.WebRootPath + $@"\{ filename}";

        //        size += file[0].Length;

        //        using (FileStream fs = System.IO.File.Create(FilePath))

        //        {

        //            file[0].CopyTo(fs);

        //            fs.Flush();

        //        }



        //        result = FilePath;

        //    }

        //    catch (Exception ex)

        //    {

        //        result = ex.Message;

        //    }



        //    return result;

        //}
    }
}
