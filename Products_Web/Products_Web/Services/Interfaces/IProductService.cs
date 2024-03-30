using Products_Web.Models.Product;

namespace Products_Web.Services.Interfaces
{
    public interface IProductService
    {
        void Add(CreateProductViewModel product);

        IEnumerable<ProductViewModel> GetAll();

        void Delete(int id);

        void Edit(ProductViewModel product);

        ProductViewModel Get(int id);
    }
}