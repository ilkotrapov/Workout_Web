using Products_Web.Data.Entities;
using Products_Web.Models.Product;

namespace Products_Web.Services.Interfaces
{
    public interface ISquatService
    {
        void Add(CreateSquatViewModel Squat);

        IEnumerable<SquatViewModel> GetAll();

        void Delete(int id);

        void Edit(EditSquatViewModel Squat);

        SquatViewModel Get(int id);

        //ToDo: Get by Id
    }
}
