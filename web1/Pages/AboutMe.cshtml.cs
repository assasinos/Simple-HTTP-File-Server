using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace web1.Pages
{
    public class AboutMeModel : PageModel
    {

        public string[] list { get; set; }    


        public System.Net.IPAddress IpAddress { get; set; }  


        private readonly ILogger<AboutMeModel> _logger;

        public AboutMeModel(ILogger<AboutMeModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            IpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            list = new string[] {"1","2","3","4"};
        }
    }
}
