using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SummernoteTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SummernoteTest.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ViewModel vm)
        {
            return View("Index", vm);
        }
    }
}
