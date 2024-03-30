using Microsoft.AspNetCore.Mvc;
using Products_Web.Models.Product;
using Products_Web.Services.Interfaces;

namespace Products_Web.Controllers
{
    public class PushUpController : Controller
    {
        private readonly IPushUpService pushupService;

        public PushUpController(IPushUpService pushupService)
        {
            this.pushupService = pushupService;
        }
        public IActionResult Index()
        {
            var pushups = pushupService.GetAll();

            return View(pushups);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePushUpViewModel pushup)
        {
            pushupService.Add(pushup);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            pushupService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var pushup = pushupService.Get(id);

            return View(pushup);
        }

        [HttpPost]
        public IActionResult Edit(EditPushUpViewModel pushup)
        {
            pushupService.Edit(pushup);

            return RedirectToAction(nameof(Index));
        }
    }
}
