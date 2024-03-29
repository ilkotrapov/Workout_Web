
using Products_Web.Data.Entities;
using Products_Web.Models.Product;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services.Interfaces;

namespace Diets_Web.Services
{
    public class DietService : IDietService
    {
        private readonly IDietRepository dietRepository;

        public DietService(IDietRepository dietRepository)
        {
            this.dietRepository = dietRepository;
        }

        public void Add(CreateDietViewModel diet)
        {
            var dietEntity = new Diet(diet.Name, diet.Duration, diet.Description);

            dietRepository.Add(dietEntity);
        }

        public IEnumerable<DietViewModel> GetAll()
        {
            var DietEntities = dietRepository.GetAll();

            var Diets = DietEntities
                .Select(Diet => new DietViewModel(Diet.Id, Diet.Name, Diet.Duration, Diet.Description));

            return Diets;
        }

        public DietViewModel Get(int id)
        {
            var Diet = dietRepository.Get(id);

            return new DietViewModel(Diet.Id, Diet.Name, Diet.Duration, Diet.Description);
        }

        public void Edit(EditDietViewModel Diet)
        {
            var DietEntity = new Diet(Diet.Id, Diet.Name, Diet.Duration, Diet.Description);

            dietRepository.Edit(DietEntity);
        }

        public void Delete(int id)
            => dietRepository.Delete(id);

       
    }
}
