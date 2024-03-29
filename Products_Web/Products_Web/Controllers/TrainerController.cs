using Microsoft.AspNetCore.Mvc;
using Products_Web.Models.Product;
using Products_Web.Services.Interfaces;

namespace Products_Web.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ITrainerService trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            this.trainerService = trainerService;
        }
        public IActionResult Index()
        {
            var trainers = trainerService.GetAll();

            return View(trainers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTrainerViewModel trainer)
        {
            trainerService.Add(trainer);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            trainerService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var trainer = trainerService.Get(id);

            return View(trainer);
        }

        [HttpPost]
        public IActionResult Edit(EditTrainerViewModel trainer)
        {
            trainerService.Edit(trainer);

            return RedirectToAction(nameof(Index));
        }
    }
}
