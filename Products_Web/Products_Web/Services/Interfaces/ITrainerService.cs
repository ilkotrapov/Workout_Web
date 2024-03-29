using Products_Web.Data.Entities;
using Products_Web.Models.Product;

namespace Products_Web.Services.Interfaces
{
    public interface ITrainerService
    {
        void Add(CreateTrainerViewModel trainer);

        IEnumerable<TrainerViewModel> GetAll();

        void Delete(int id);

        void Edit(EditTrainerViewModel trainer);

        TrainerViewModel Get(int id);

        //ToDo: Get by Id
    }
}
