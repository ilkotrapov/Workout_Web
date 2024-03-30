using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories.Interfaces;

namespace Products_Web.Repositories
{
    public class PushUpRepository : IPushUpRepository
    {
        private readonly ApplicationContext context;

        public PushUpRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Add(PushUp pushups)
        {
            if (pushups == null)
            {
                throw new ArgumentException("PushUp can't be null!");
            }
            context.PushUps.Add(pushups);
            context.SaveChanges();
        }

        public IEnumerable<PushUp> GetAll()
            => context.PushUps.ToList();

        public void Delete(int id)
        {
            var pushup = Get(id);
            //ToDo: add null value validation

            context.PushUps.Remove(pushup);
            context.SaveChanges();
        }

        public void Edit(PushUp pushup)
        {
            var entity = Get(pushup.Id);

            entity.Name = pushup.Name;
            entity.Difficulty = pushup.Difficulty;
            entity.Type = pushup.Type;

            context.SaveChanges();
        }//Has to be added to the interface

        public PushUp Get(int id)
            => context.PushUps.FirstOrDefault(pushup => pushup.Id == id);

    }
}
