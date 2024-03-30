using Microsoft.AspNetCore.Mvc;
using Products_Web.Models.Product;
using Products_Web.Services.Interfaces;

namespace Products_Web.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseService exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }
        public IActionResult Index()
        {
            var exercises = exerciseService.GetAll();

            return View(exercises);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateExerciseViewModel exercise)
        {
            exerciseService.Add(exercise);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            exerciseService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var exercise = exerciseService.Get(id);

            return View(exercise);
        }

        [HttpPost]
        public IActionResult Edit(EditExerciseViewModel exercise)
        {
            exerciseService.Edit(exercise);

            return RedirectToAction(nameof(Index));
        }
    }
}
