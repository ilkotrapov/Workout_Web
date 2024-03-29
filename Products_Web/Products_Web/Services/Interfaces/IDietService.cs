using Products_Web.Data.Entities;
using Products_Web.Models.Product;

namespace Products_Web.Services.Interfaces
{
    public interface IDietService
    {
        void Add(CreateDietViewModel Diet);

        IEnumerable<DietViewModel> GetAll();

        void Delete(int id);

        void Edit(EditDietViewModel Diet);

        DietViewModel Get(int id);

        //ToDo: Get by Id
    }
}
