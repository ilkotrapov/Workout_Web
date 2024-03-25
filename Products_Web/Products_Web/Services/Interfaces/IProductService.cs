using Products_Web.Data.Entities;
using Products_Web.Models.Product;

namespace Products_Web.Services.Interfaces
{
    public interface IProductService
    {
        void Add(CreateProductViewModel product);

        IEnumerable<ProductViewModel> GetAll();

        void Delete(int id);

        void Edit(EditProductViewModel product);

        ProductViewModel Get(int id);

        //ToDo: Get by Id
    }
}
