
using Products_Web.Data.Entities;
using Products_Web.Models.Product;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services.Interfaces;

namespace Exercises_Web.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            this.exerciseRepository = exerciseRepository;
        }

        public void Add(CreateExerciseViewModel exercise)
        {
            var exerciseEntity = new Exercise(exercise.Name, exercise.Difficulty, exercise.Type);

            exerciseRepository.Add(exerciseEntity);
        }

        public IEnumerable<ExerciseViewModel> GetAll()
        {
            var exerciseEntities = exerciseRepository.GetAll();

            var exercises = exerciseEntities
                .Select(exercise => new ExerciseViewModel(exercise.Id, exercise.Name, exercise.Difficulty, exercise.Type));

            return exercises;
        }

        public ExerciseViewModel Get(int id)
        {
            var exercise = exerciseRepository.Get(id);

            return new ExerciseViewModel(exercise.Id, exercise.Name, exercise.Difficulty, exercise.Type);
        }

        public void Edit(EditExerciseViewModel exercise)
        {
            var exerciseEntity = new Exercise(exercise.Id, exercise.Name, exercise.Difficulty, exercise.Type);

            exerciseRepository.Edit(exerciseEntity);
        }

        public void Delete(int id)
            => exerciseRepository.Delete(id);


    }
}
