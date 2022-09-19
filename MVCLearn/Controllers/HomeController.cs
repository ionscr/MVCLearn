using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCLearn.Models;

namespace MVCLearn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Home page");
            ViewBag.Title = "MVCLearn";
            return View();
        }
    }
}
