using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories.Interfaces;

namespace Products_Web.Repositories
{
    public class DietRepository : IDietRepository
    {
        private readonly ApplicationContext context;

        public DietRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Add(Diet diet)
        {
            if (diet == null)
            {
                throw new ArgumentException("Diet can't be null!");
            }
            context.Diets.Add(diet);
            context.SaveChanges();
        }

        public IEnumerable<Diet> GetAll()
            => context.Diets.ToList();

        public void Delete(int id)
        {
            var diet = Get(id);
            //ToDo: add null value validation

            context.Diets.Remove(diet);
            context.SaveChanges();
        }

        public void Edit(Diet diet)
        {
            var entity = Get(diet.Id);

            entity.Name = diet.Name;
            entity.Duration = diet.Duration;
            entity.Description = diet.Description;

            context.SaveChanges();
        }//Has to be added to the interface

        public Diet Get(int id)
            => context.Diets.FirstOrDefault(Diet => Diet.Id == id);

    }
}
