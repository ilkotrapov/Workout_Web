using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories.Interfaces;

namespace Products_Web.Repositories
{
    public class SquatRepository : ISquatRepository
    {
        private readonly ApplicationContext context;

        public SquatRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Add(Squat Squats)
        {
            if (Squats == null)
            {
                throw new ArgumentException("Squat can't be null!");
            }
            context.Squats.Add(Squats);
            context.SaveChanges();
        }

        public IEnumerable<Squat> GetAll()
            => context.Squats.ToList();

        public void Delete(int id)
        {
            var Squat = Get(id);
            //ToDo: add null value validation

            context.Squats.Remove(Squat);
            context.SaveChanges();
        }

        public void Edit(Squat Squat)
        {
            var entity = Get(Squat.Id);

            entity.Name = Squat.Name;
            entity.Difficulty = Squat.Difficulty;
            entity.Type = Squat.Type;

            context.SaveChanges();
        }//Has to be added to the interface

        public Squat Get(int id)
            => context.Squats.FirstOrDefault(Squat => Squat.Id == id);

    }
}
