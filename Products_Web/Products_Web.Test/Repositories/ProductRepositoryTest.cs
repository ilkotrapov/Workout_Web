using Microsoft.EntityFrameworkCore;
using Moq;
using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Web.Test.Repositories
{
    public class ProductRepositoryTest
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
            var product = new Product("new Product", 10, 100);

            productRepository.Add(product);

            var createdProduct = applicationContext.Products.LastOrDefault();

            Assert.NotNull(createdProduct, "Product is null");
            Assert.AreEqual(product.Name, createdProduct.Name,"NO NAME");
            Assert.AreEqual(product.Price, createdProduct.Price, "NO PRICE");
            Assert.AreEqual(product.Stock, createdProduct.Stock, "NO STOCK");
        }

        public void GivenAProduct_WhenAddingAProduct_Throws()
        {
            var exception = Assert.Throws<ArgumentException>(() => productRepository.Add(null));

            Assert.AreEqual("Product can't be null", exception.Message, "Exception message is different");
        }
        #endregion

        #region GetAll
        [Test]
        public void WhenGettingAll_ReturnsAllProducts()
        {
            var expectedProducts = new[]
            {
                new Product(1,"product1",10,100),
                new Product(2,"product2",12,110),
                new Product(3,"product3",10,220)
            };
            applicationContext.Products.AddRange(expectedProducts);
            applicationContext.SaveChanges();

            var products = productRepository.GetAll();

            Assert.AreEqual(expectedProducts, products, "no");
        }
        #endregion
        private ApplicationContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase("UnitTestDb");

            return new ApplicationContext(options.Options);
        }
    }
}
