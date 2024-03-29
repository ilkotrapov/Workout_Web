using Microsoft.EntityFrameworkCore;
using Moq;
using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories;
using Microsoft.EntityFrameworkCore;
using Products_Web.Data;

namespace Products_Web.Tests.Repositories
{
    public class ProductRepositoryTests
    {
        private ProductRepository productRepository;

        private ApplicationContext applicationContext;

        [SetUp]
        public void SetUp()
        {
            applicationContext = SetUpApplicationContext();
            productRepository = new ProductRepository(applicationContext);
        }

        [TearDown]
        public void TearDown()
        {
            applicationContext.Database.EnsureDeleted();
        }

        #region Add
        [Test]
        public void GivenAProduct_WhenAddingAProduct_AddsIt()
        {
            var product = new Product("new product", 10, 100, new ProductDetails("calories: 100", DateTime.Now));

            productRepository.Add(product);

            var createdProduct = applicationContext.Products.LastOrDefault();

            Assert.AreEqual(product, createdProduct, "Product is different than expected");
        }

        [Test]
        public void GivenNullProduct_WhenAddingAProduct_Throws()
        {
            var exception = Assert.Throws<ArgumentException>(() => productRepository.Add(null));

            Assert.AreEqual(
                "Product can't be null!",
                exception.Message,
                "Exception message is different than expected");
        }
        #endregion

        #region GetAll
        [Test]
        public void WhenGettingAll_ReturnsAllProducts()
        {
            var expectedProducts = SeedProducts();

            var products = productRepository.GetAll();

            Assert.AreEqual(expectedProducts, products);
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingAProduct_ReturnsTheProduct()
        {
            var expectedProducts = SeedProducts();
            var expectedProduct = expectedProducts.First();

            var product = productRepository.Get(expectedProduct.Id);

            Assert.AreEqual(expectedProduct, product, "Product is different than expected");
        }

        [Test]
        public void GivenNonExistingId_WhenGettingAProduct_ReturnsTheProduct()
        {
            SeedProducts();
            var nonExistingId = -1;

            var product = productRepository.Get(nonExistingId);

            Assert.Null(product);
        }
        #endregion

        private IEnumerable<Product> SeedProducts()
        {
            var products = new[]
            {
                  new Product(1, "product1", 10, 100, new ProductDetails(1, "calories: 100", DateTime.Now)),
                  new Product(2, "product2", 15, 60, new ProductDetails(2, "calories: 569", DateTime.Now)),
                  new Product(3, "product3", 300, 5, new ProductDetails(3, "none", DateTime.Now))
            };
            applicationContext.Products.AddRange(products);
            applicationContext.SaveChanges();

            return products;
        }
        private ApplicationContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UnitTestsDb");

            return new ApplicationContext(options.Options);
        }
    }
}
