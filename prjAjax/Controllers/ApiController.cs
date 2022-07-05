using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using prjAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjAjax.Controllers
{
    public class ApiController : Controller
    {

        private readonly DemoContext _conetext;
        public ApiController(DemoContext conetext, IWebHostEnvironment hostEnvironment)
        {
            _conetext = conetext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult City()
        {
            var cities = _conetext.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }

        public IActionResult Districts(string city)
        {
            var districts = _conetext.Addresses.Where(a => a.City == city).Select(a => a.SiteId).Distinct();
            return Json(districts);
        }

        public IActionResult Roads(string districts)
        {
            var roads = _conetext.Addresses.Where(a => a.SiteId == districts).Select(a => a.Road);
            return Json(roads);
        }
        public IActionResult Citys()
        {
            return Json(_conetext.Addresses);
        }

    }
}
