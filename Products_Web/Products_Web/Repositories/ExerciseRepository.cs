using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories.Interfaces;

namespace Products_Web.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationContext context;

        public ExerciseRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Add(Exercise exercises)
        {
            if (exercises == null)
            {
                throw new ArgumentException("Exercise can't be null!");
            }
            context.Exercises.Add(exercises);
            context.SaveChanges();
        }

        public IEnumerable<Exercise> GetAll()
            => context.Exercises.ToList();

        public void Delete(int id)
        {
            var exercise = Get(id);
            //ToDo: add null value validation

            context.Exercises.Remove(exercise);
            context.SaveChanges();
        }

        public void Edit(Exercise exercise)
        {
            var entity = Get(exercise.Id);

            entity.Name = exercise.Name;
            entity.Difficulty = exercise.Difficulty;
            entity.Type = exercise.Type;

            context.SaveChanges();
        }//Has to be added to the interface

        public Exercise Get(int id)
            => context.Exercises.FirstOrDefault(exercise => exercise.Id == id);

    }
}
