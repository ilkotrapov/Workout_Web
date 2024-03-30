
using Products_Web.Data.Entities;
using Products_Web.Models.Product;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services.Interfaces;

namespace PullUps_Web.Services
{
    public class PullUpService : IPullUpService
    {
        private readonly IPullUpRepository PullUpRepository;

        public PullUpService(IPullUpRepository PullUpRepository)
        {
            this.PullUpRepository = PullUpRepository;
        }

        public void Add(CreatePullUpViewModel PullUp)
        {
            var PullUpEntity = new PullUp(PullUp.Name, PullUp.Difficulty, PullUp.Type);

            PullUpRepository.Add(PullUpEntity);
        }

        public IEnumerable<PullUpViewModel> GetAll()
        {
            var PullUpEntities = PullUpRepository.GetAll();

            var PullUps = PullUpEntities
                .Select(PullUp => new PullUpViewModel(PullUp.Id, PullUp.Name, PullUp.Difficulty, PullUp.Type));

            return PullUps;
        }

        public PullUpViewModel Get(int id)
        {
            var PullUp = PullUpRepository.Get(id);

            return new PullUpViewModel(PullUp.Id, PullUp.Name, PullUp.Difficulty, PullUp.Type);
        }

        public void Edit(EditPullUpViewModel PullUp)
        {
            var PullUpEntity = new PullUp(PullUp.Id, PullUp.Name, PullUp.Difficulty, PullUp.Type);

            PullUpRepository.Edit(PullUpEntity);
        }

        public void Delete(int id)
            => PullUpRepository.Delete(id);


    }
}
