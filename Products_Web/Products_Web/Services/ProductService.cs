using Products_Web.Data.Entities;
using Products_Web.Models.Product;
using Products_Web.Repositories;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services.Interfaces;

namespace Products_Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Add(CreateProductViewModel product)
        {
            var productEntity = new Product(product.Name, product.Price, product.Stock);

            productRepository.Add(productEntity);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var productEntities = productRepository.GetAll();

            var products = productEntities
                .Select(product => new ProductViewModel(product.Id, product.Name, product.Price, product.Stock));

            return products;
        }

        public ProductViewModel Get(int id)
        {
            var product = productRepository.Get(id);

            return new ProductViewModel(product.Id, product.Name, product.Price, product.Stock);
        }

        public void Edit(EditProductViewModel product)
        {
            var productEntity = new Product(product.Id, product.Name, product.Price, product.Stock);

            productRepository.Edit(productEntity);
        }

        public void Delete(int id)
            => productRepository.Delete(id);

       
    }
}
