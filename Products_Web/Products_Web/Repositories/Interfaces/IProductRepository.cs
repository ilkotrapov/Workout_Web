using Products_Web.Data.Entities;
using Products_Web.Models.Product;

namespace Products_Web.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);

        IEnumerable<Product> GetAll();

        void Delete(int id);

        void Edit(Product product);
        //void Edit(EditProductViewModel product);

        Product Get(int id);
    }
}
