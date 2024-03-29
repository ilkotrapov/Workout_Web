using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Products_Web.Data.Entities;
using Products_Web.Models.Product;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services;

namespace Products_Web.Tests.Services
{
    public class ProductServiceTests
    {
        private ProductService productService;

        private Mock<IProductRepository> productRepositoryMock;

        private readonly IEnumerable<Product> productsInDatabase;

        public ProductServiceTests()
        {
            productsInDatabase = new[]
            {
                new Product(1, "product1", 10, 100, new ProductDetails(1, "calories: 100", DateTime.Now)),
                new Product(2, "product2", 15, 60, new ProductDetails(2, "calories: 569", DateTime.Now)),
                new Product(3, "product3", 300, 5, new ProductDetails(3, "none", DateTime.Now))
            };
        }

        [SetUp]
        public void SetUp()
        {
            productRepositoryMock = SetUpProductRepositoryMock();

            productService = new ProductService(productRepositoryMock.Object);
        }

        #region Add
        [Test]
        public void GivenValidProduct_WhenAddingAProduct_TheProductIsAdded()
        {

            var product = new CreateProductViewModel()
            {
                Name = "product",
                Price = 10,
                Stock = 123,
                NutritionInformation = "calories: 100",
                ExpirationDate = DateTime.Now
            };
            productService.Add(product);

            productRepositoryMock.Verify(
                mock => mock.Add(It.Is<Product>(productEntity =>
                    productEntity.Name == product.Name &&
                    productEntity.Price == product.Price &&
                    productEntity.Stock == product.Stock)),
                Times.Once);
        }
        #endregion

        #region GetAll
        [Test]
        public void GivenProductsExist_WhenGettingAllProducts_AllProductsAreReturned()
        {
            var products = productService.GetAll();

            Assert.AreEqual(
                productsInDatabase.Count(),
                products.Count(),
                "Products count different than expected");

            foreach (var productInDatabase in productsInDatabase)
            {
                var productExists = products.Any(product =>
                        product.Id == productInDatabase.Id &&
                        product.Name == productInDatabase.Name &&
                        product.Price == productInDatabase.Price &&
                        product.Stock == productInDatabase.Stock);

                Assert.True(
                    productExists,
                    $"Product with Id {productInDatabase.Id} doesn't exist");
            }
        }

        [Test]
        public void GivenNoProductsExist_WhenGettingAllProducts_ReturnsEmptyCollection()
        {
            productRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(new List<Product>());

            var products = productService.GetAll();

            Assert.AreEqual(0, products.Count());
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingAProduct_ReturnsTheProduct()
        {
            var expectedProduct = productsInDatabase.First();

            var product = productService.Get(expectedProduct.Id);

            Assert.AreEqual(expectedProduct.Id, product.Id);
            Assert.AreEqual(expectedProduct.Name, product.Name);
            Assert.AreEqual(expectedProduct.Price, product.Price);
            Assert.AreEqual(expectedProduct.Stock, product.Stock);
        }
        #endregion

        private Mock<IProductRepository> SetUpProductRepositoryMock()
        {
            var productRepositoryMock = new Mock<IProductRepository>();

            productRepositoryMock.Setup(mock => mock.Add(It.IsAny<Product>()));

            productRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(productsInDatabase);

            productRepositoryMock
                .Setup(mock => mock.Get(productsInDatabase.First().Id))
                .Returns(productsInDatabase.First());

            return productRepositoryMock;
        }
    }
}