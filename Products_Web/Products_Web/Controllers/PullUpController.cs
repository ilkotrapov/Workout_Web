using Microsoft.AspNetCore.Mvc;
using Products_Web.Models.Product;
using Products_Web.Services.Interfaces;

namespace Products_Web.Controllers
{
    public class PullUpController : Controller
    {
        private readonly IPullUpService PullUpService;

        public PullUpController(IPullUpService PullUpService)
        {
            this.PullUpService = PullUpService;
        }
        public IActionResult Index()
        {
            var PullUp = PullUpService.GetAll();

            return View(PullUp);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePullUpViewModel PullUp)
        {
            PullUpService.Add(PullUp);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            PullUpService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var PullUp = PullUpService.Get(id);

            return View(PullUp);
        }

        [HttpPost]
        public IActionResult Edit(EditPullUpViewModel PullUp)
        {
            PullUpService.Edit(PullUp);

            return RedirectToAction(nameof(Index));
        }
    }
}
