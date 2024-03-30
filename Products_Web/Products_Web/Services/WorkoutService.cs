
using Products_Web.Data.Entities;
using Products_Web.Models.Product;
using Products_Web.Models.Workout;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services.Interfaces;

namespace Workouts_Web.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            this.workoutRepository = workoutRepository;
        }

        public void Add(CreateWorkoutViewModel workout)
        {
            var workoutEntity = new Workout(workout.Name, workout.Duration, workout.Place);

            workoutRepository.Add(workoutEntity);
        }

        public IEnumerable<WorkoutViewModel> GetAll()
        {
            var workoutEntities = workoutRepository.GetAll();

            var workouts = workoutEntities
                .Select(workout => new WorkoutViewModel(workout.Id, workout.Name, workout.Duration, workout.Place));

            return workouts;
        }

        public WorkoutViewModel Get(int id)
        {
            var workout = workoutRepository.Get(id);

            return new WorkoutViewModel(workout.Id, workout.Name, workout.Duration, workout.Place);
        }

        public void Edit(EditWorkoutViewModel workout)
        {
            var workoutEntity = new Workout(workout.Id, workout.Name, workout.Duration, workout.Place);

            workoutRepository.Edit(workoutEntity);
        }

        public void Delete(int id)
            => workoutRepository.Delete(id);

       
    }
}
