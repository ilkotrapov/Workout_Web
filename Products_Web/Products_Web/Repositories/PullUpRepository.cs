using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories.Interfaces;

namespace Products_Web.Repositories
{
    public class PullUpRepository : IPullUpRepository
    {
        private readonly ApplicationContext context;

        public PullUpRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Add(PullUp PullUps)
        {
            if (PullUps == null)
            {
                throw new ArgumentException("PullUp can't be null!");
            }
            context.PullUps.Add(PullUps);
            context.SaveChanges();
        }

        public IEnumerable<PullUp> GetAll()
            => context.PullUps.ToList();

        public void Delete(int id)
        {
            var PullUp = Get(id);
            //ToDo: add null value validation

            context.PullUps.Remove(PullUp);
            context.SaveChanges();
        }

        public void Edit(PullUp PullUp)
        {
            var entity = Get(PullUp.Id);

            entity.Name = PullUp.Name;
            entity.Difficulty = PullUp.Difficulty;
            entity.Type = PullUp.Type;

            context.SaveChanges();
        }//Has to be added to the interface

        public PullUp Get(int id)
            => context.PullUps.FirstOrDefault(PullUp => PullUp.Id == id);

    }
}
