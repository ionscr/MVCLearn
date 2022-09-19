using Microsoft.AspNetCore.Mvc;

namespace MVCLearn.Controllers
{
    public class CoffeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
