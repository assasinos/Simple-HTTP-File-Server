using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Diagnostics;

namespace web1.Pages
{
    public class DownloadPageModel : PageModel
    {
        private Dictionary<string, string> keys = new Dictionary<string, string>()
        {
            {".txt", "text/plain" },
            {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            {".doc", "application/msword" },
            {".pdf","application/pdf" },
            {".jpeg", "image/jpeg"},
            {".jpg", "image/jpeg"},
            {".png", "image/png"},
            {".odt", "application/vnd.oasis.opendocument.text" },
            {".mp4", "video/mp4" }

        };

        


        public ActionResult OnGet()
        {
            if (HttpContext.Request.Query["file"] == "" || HttpContext.Request.Query["extension"] == "") return Page();

            if(keys.ContainsKey(HttpContext.Request.Query["extension"])) return File("/Files/" + HttpContext.Request.Query["file"].ToString(), keys[HttpContext.Request.Query["extension"]],
                                                                        $"{HttpContext.Request.Query["file"].ToString()}");
            return File("/Files/" + HttpContext.Request.Query["file"].ToString(), "text/plain",
            $"{HttpContext.Request.Query["file"].ToString()}");


            //
        }
    }
}
