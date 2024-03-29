
using Products_Web.Data.Entities;
using Products_Web.Models.Product;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services.Interfaces;

namespace Trainers_Web.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository trainerRepository;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            this.trainerRepository = trainerRepository;
        }

        public void Add(CreateTrainerViewModel trainer)
        {
            var trainerEntity = new Trainer(trainer.Name, trainer.Email, trainer.Gym);

            trainerRepository.Add(trainerEntity);
        }

        public IEnumerable<TrainerViewModel> GetAll()
        {
            var trainerEntities = trainerRepository.GetAll();

            var trainers = trainerEntities
                .Select(trainer => new TrainerViewModel(trainer.Id, trainer.Name, trainer.Email, trainer.Gym));

            return trainers;
        }

        public TrainerViewModel Get(int id)
        {
            var trainer = trainerRepository.Get(id);

            return new TrainerViewModel(trainer.Id, trainer.Name, trainer.Email, trainer.Gym);
        }

        public void Edit(EditTrainerViewModel trainer)
        {
            var trainerEntity = new Trainer(trainer.Id, trainer.Name, trainer.Email, trainer.Gym);

            trainerRepository.Edit(trainerEntity);
        }

        public void Delete(int id)
            => trainerRepository.Delete(id);

       
    }
}
