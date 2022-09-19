using Microsoft.AspNetCore.Mvc;

namespace MVCLearn.Controllers
{
    public class MaintenanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
