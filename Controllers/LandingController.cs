using Microsoft.AspNetCore.Mvc;

namespace Empleo.Controllers
{
    public class LandingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}