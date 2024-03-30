
using Products_Web.Data.Entities;
using Products_Web.Models.Product;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services.Interfaces;

namespace PushUps_Web.Services
{
    public class PushUpService : IPushUpService
    {
        private readonly IPushUpRepository pushupRepository;

        public PushUpService(IPushUpRepository pushupRepository)
        {
            this.pushupRepository = pushupRepository;
        }

        public void Add(CreatePushUpViewModel pushup)
        {
            var pushupEntity = new PushUp(pushup.Name, pushup.Difficulty, pushup.Type);

            pushupRepository.Add(pushupEntity);
        }

        public IEnumerable<PushUpViewModel> GetAll()
        {
            var pushupEntities = pushupRepository.GetAll();

            var pushups = pushupEntities
                .Select(pushup => new PushUpViewModel(pushup.Id, pushup.Name, pushup.Difficulty, pushup.Type));

            return pushups;
        }

        public PushUpViewModel Get(int id)
        {
            var pushup = pushupRepository.Get(id);

            return new PushUpViewModel(pushup.Id, pushup.Name, pushup.Difficulty, pushup.Type);
        }

        public void Edit(EditPushUpViewModel pushup)
        {
            var pushupEntity = new PushUp(pushup.Id, pushup.Name, pushup.Difficulty, pushup.Type);

            pushupRepository.Edit(pushupEntity);
        }

        public void Delete(int id)
            => pushupRepository.Delete(id);


    }
}
