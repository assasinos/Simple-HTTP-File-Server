using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using web1.Models;


namespace web1.Models
{
    public class delete
    {
        public string filename { get; set; }
    }


    public class fileitem
    {
        public IFormFile fileInfo { get; set; }
    }
}

namespace web1.Pages
{


    public class IndexModel : PageModel
    {
        [BindProperty]
        public delete delete { get; set; }
        [BindProperty]
        public fileitem fileitem { get; set; }

        private readonly ILogger<IndexModel> _logger;


        public List<FileInfo> fileInfos = new List<FileInfo>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            /*            string path = AppContext.BaseDirectory;
                        path = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));*/


            if (!Directory.Exists("wwwroot/Files"))
            {
                Directory.CreateDirectory("wwwroot/Files");
            }
            foreach (var file in Directory.GetFiles("wwwroot/Files"))//+ "/wwwroot/Files"))
            {
                fileInfos.Add(new FileInfo(file));

            }
        }
        public async Task<IActionResult> OnPostUploadAsync(IFormFile file)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            using (var stream = System.IO.File.Create("wwwroot/Files/" + fileitem.fileInfo.FileName.ToString()))
            {
                await fileitem.fileInfo.CopyToAsync(stream);
            }


            return Redirect(Request.HttpContext.Request.Path);
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var file = new FileInfo("wwwroot/Files/" + delete.filename);//path + "/wwwroot/Files/" + delete.filename);

            file.Delete();
            return Redirect(Request.HttpContext.Request.Path);
        }



        public List<string> images = new List<string>
        {
            ".jpg",
            ".png",
            ".jfif",
            ".jpeg",
            ".pdf",
            ".mp3",
            ".html",
            ".htm",
            ".txt",
            ".md"

        };


    }
}