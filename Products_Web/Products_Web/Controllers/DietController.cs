using Microsoft.AspNetCore.Mvc;
using Products_Web.Models.Product;
using Products_Web.Services.Interfaces;

//bomboclat controller

namespace Products_Web.Controllers
{
    public class DietController : Controller
    {
        private readonly IDietService DietService;

        public DietController(IDietService DietService)
        {
            this.DietService = DietService;
        }
        public IActionResult Index()
        {
            var Diets = DietService.GetAll();

            return View(Diets);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDietViewModel Diet)
        {
            DietService.Add(Diet);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            DietService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var Diet = DietService.Get(id);

            return View(Diet);
        }

        [HttpPost]
        public IActionResult Edit(EditDietViewModel Diet)
        {
            DietService.Edit(Diet);

            return RedirectToAction(nameof(Index));
        }
    }
}
