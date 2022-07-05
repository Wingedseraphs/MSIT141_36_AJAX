using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjAjax.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace prjAjax.Controllers
{
    public class HomeController : Controller
    {

        private readonly DemoContext _conetext;
        private readonly IWebHostEnvironment _host;
        public HomeController(DemoContext conetext, IWebHostEnvironment hostEnvironment)
        {
            _conetext = conetext;
            _host = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register(Member member)
        {
            
            return View();
        }

        public IActionResult CheckAccount(string name)
        {
            var exists = _conetext.Members.Any(m => m.Name == name);
            return Content(exists.ToString(), "text/plain");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
