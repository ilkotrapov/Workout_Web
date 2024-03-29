using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories.Interfaces;

namespace Products_Web.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly ApplicationContext context;

        public TrainerRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Add(Trainer trainer)
        {
            if (trainer == null)
            {
                throw new ArgumentException("Trainer can't be null!");
            }
            context.Trainers.Add(trainer);
            context.SaveChanges();
        }

        public IEnumerable<Trainer> GetAll()
            => context.Trainers.ToList();

        public void Delete(int id)
        {
            var trainer = Get(id);
            //ToDo: add null value validation

            context.Trainers.Remove(trainer);
            context.SaveChanges();
        }

        public void Edit(Trainer trainer)
        {
            var entity = Get(trainer.Id);

            entity.Name = trainer.Name;
            entity.Email = trainer.Email;
            entity.Gym = trainer.Gym;

            context.SaveChanges();
        }//Has to be added to the interface

        public Trainer Get(int id)
            => context.Trainers.FirstOrDefault(trainer => trainer.Id == id);

    }
}
