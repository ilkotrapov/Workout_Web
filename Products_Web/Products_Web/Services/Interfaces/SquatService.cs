
using Products_Web.Data.Entities;
using Products_Web.Models.Product;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services.Interfaces;

namespace Squats_Web.Services
{
    public class SquatService : Isquatservice
    {
        private readonly ISquatRepository SquatRepository;

        public SquatService(ISquatRepository SquatRepository)
        {
            this.SquatRepository = SquatRepository;
        }

        public void Add(CreateSquatViewModel Squat)
        {
            var SquatEntity = new Squat(Squat.Name, Squat.Difficulty, Squat.Type);

            SquatRepository.Add(SquatEntity);
        }

        public IEnumerable<SquatViewModel> GetAll()
        {
            var SquatEntities = SquatRepository.GetAll();

            var Squats = SquatEntities
                .Select(Squat => new SquatViewModel(Squat.Id, Squat.Name, Squat.Difficulty, Squat.Type));

            return Squats;
        }

        public SquatViewModel Get(int id)
        {
            var Squat = SquatRepository.Get(id);

            return new SquatViewModel(Squat.Id, Squat.Name, Squat.Difficulty, Squat.Type);
        }

        public void Edit(EditSquatViewModel Squat)
        {
            var SquatEntity = new Squat(Squat.Id, Squat.Name, Squat.Difficulty, Squat.Type);

            SquatRepository.Edit(SquatEntity);
        }

        public void Delete(int id)
            => SquatRepository.Delete(id);


    }
}
