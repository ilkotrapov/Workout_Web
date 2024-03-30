/*using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Models.Product;
using Products_Web.Repositories.Interfaces;

namespace Products_Web.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext context;

        public ProductRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Add(Product product)
        {
            if (product is null)
            {
                throw new ArgumentException("Product can't be null!");
            }

            context.ProductDetails.Add(product.Details);
            context.Products.Add(product);

            context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
            => context.Products.ToList();

        public void Delete(int id)
        {
            var product = Get(id);
            // ToDo: add null value validation

            context.Products.Remove(product);
            context.SaveChanges();
        }

        public void Edit(ProductViewModel product)
        {
            var entity = Get(product.Id);

            entity.Name = product.Name;
            entity.Stock = product.Stock;
            entity.Price = product.Price;
            entity.Details.NutritionInformation = product.NutritionInformation;
            entity.Details.ExpirationDate = product.ExpirationDate;

            context.SaveChanges();
        }

        public Product Get(int id)
            => context.Products.FirstOrDefault(product => product.Id == id);
    }
}*/