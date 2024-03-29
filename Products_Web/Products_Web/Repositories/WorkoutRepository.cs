using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories.Interfaces;

namespace Products_Web.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly ApplicationContext context;

        public WorkoutRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Add(Workout workout)
        {
            if (workout == null)
            {
                throw new ArgumentException("Workout can't be null!");
            }
            context.Workouts.Add(workout);
            context.SaveChanges();
        }

        public IEnumerable<Workout> GetAll()
            => context.Workouts.ToList();

        public void Delete(int id)
        {
            var workout = Get(id);
            //ToDo: add null value validation

            context.Workouts.Remove(workout);
            context.SaveChanges();
        }

        public void Edit(Workout workout)
        {
            var entity = Get(workout.Id);

            entity.Name = workout.Name;
            entity.Duration = workout.Duration;
            entity.Place = workout.Place;

            context.SaveChanges();
        }//Has to be added to the interface

        public Workout Get(int id)
            => context.Workouts.FirstOrDefault(workout => workout.Id == id);

    }
}
