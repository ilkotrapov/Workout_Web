using Microsoft.AspNetCore.Mvc;

namespace Products_Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}