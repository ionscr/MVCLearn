using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLearn.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ErrorPage()
        {
            return View();
        }
        public IActionResult NotFoundPage()
        {
            return View();
        }
    }
}
