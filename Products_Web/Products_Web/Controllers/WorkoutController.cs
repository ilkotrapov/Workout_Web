using Microsoft.AspNetCore.Mvc;
using Products_Web.Models.Product;
using Products_Web.Models.Workout;
using Products_Web.Services.Interfaces;

namespace Products_Web.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly IWorkoutService workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            this.workoutService = workoutService;
        }
        public IActionResult Index()
        {
            var workouts = workoutService.GetAll();

            return View(workouts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateWorkoutViewModel workout)
        {
            workoutService.Add(workout);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            workoutService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var workout = workoutService.Get(id);

            return View(workout);
        }

        [HttpPost]
        public IActionResult Edit(EditWorkoutViewModel workout)
        {
            workoutService.Edit(workout);

            return RedirectToAction(nameof(Index));
        }
    }
}
