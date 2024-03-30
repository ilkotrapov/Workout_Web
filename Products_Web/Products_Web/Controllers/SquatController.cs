using Microsoft.AspNetCore.Mvc;
using Products_Web.Models.Product;
using Products_Web.Services.Interfaces;

namespace Products_Web.Controllers
{
    public class SquatController : Controller
    {
        private readonly ISquatService SquatService;

        public SquatController(ISquatService SquatService)
        {
            this.SquatService = SquatService;
        }
        public IActionResult Index()
        {
            var Squats = SquatService.GetAll();

            return View(Squats);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateSquatViewModel Squat)
        {
            SquatService.Add(Squat);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            SquatService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var Squat = SquatService.Get(id);

            return View(Squat);
        }

        [HttpPost]
        public IActionResult Edit(EditSquatViewModel Squat)
        {
            SquatService.Edit(Squat);

            return RedirectToAction(nameof(Index));
        }
    }
}
