
using Products_Web.Data.Entities;
using Products_Web.Models.Product;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services.Interfaces;

namespace Squats_Web.Services
{
    public class SquatService : ISquatService
    {
        private readonly ISquatRepository squatRepository;

        public SquatService(ISquatRepository squatRepository)
        {
            this.squatRepository = squatRepository;
        }

        public void Add(CreateSquatViewModel squat)
        {
            var squatEntity = new Squat(squat.Name, squat.Difficulty, squat.Type);

            squatRepository.Add(squatEntity);
        }

        public IEnumerable<SquatViewModel> GetAll()
        {
            var squatEntities = squatRepository.GetAll();

            var squats = squatEntities
                .Select(squat => new SquatViewModel(squat.Id, squat.Name, squat.Difficulty, squat.Type));

            return squats;
        }

        public SquatViewModel Get(int id)
        {
            var squat = squatRepository.Get(id);

            return new SquatViewModel(squat.Id, squat.Name, squat.Difficulty, squat.Type);
        }

        public void Edit(EditSquatViewModel squat)
        {
            var squatEntity = new Squat(squat.Id, squat.Name, squat.Difficulty, squat.Type);

            squatRepository.Edit(squatEntity);
        }

        public void Delete(int id)
            => squatRepository.Delete(id);


    }
}
