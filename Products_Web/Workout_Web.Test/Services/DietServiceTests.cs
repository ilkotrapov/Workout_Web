using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diets_Web.Services;
using Moq;
using Products_Web.Data.Entities;
using Products_Web.Models.Product;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services;

namespace Diet_Web.Tests.Services
{
    public class DietServiceTests
    {
        private DietService DietService;

        private Mock<IDietRepository> DietRepositoryMock;

        private readonly IEnumerable<Diet> DietsInDatabase;

        public DietServiceTests()
        {
            DietsInDatabase = new[]
            {
                new Diet(1, "new Diet 1", "10min", "Wow mnogo trudno"),
                new Diet(2, "new Diet 2", "101min", "Wow mnogo lesno"),
                new Diet(3, "new Diet 3", "1023min", "Wow mnogo qko")
            };
        }

        [SetUp]
        public void SetUp()
        {
            DietRepositoryMock = SetUpDietRepositoryMock();

            DietService = new DietService(DietRepositoryMock.Object);
        }

        #region Add
        [Test]
        public void GivenValidDiet_WhenAddingADiet_TheDietIsAdded()
        {

            var Diet = new CreateDietViewModel()
            {
                Name = "Diet",
                Duration = "10min",
                Description = "Wow mnogo trudno"
            };
            DietService.Add(Diet);

            DietRepositoryMock.Verify(
                mock => mock.Add(It.Is<Diet>(DietEntity =>
                    DietEntity.Name == Diet.Name &&
                    DietEntity.Duration == Diet.Duration &&
                    DietEntity.Description == Diet.Description)),
                Times.Once);
        }
        #endregion

        #region GetAll
        [Test]
        public void GivenDietsExist_WhenGettingAllDiets_AllDietsAreReturned()
        {
            var Diets = DietService.GetAll();

            Assert.AreEqual(
                DietsInDatabase.Count(),
                Diets.Count(),
                "Diets count different than expected");

            foreach (var DietInDatabase in DietsInDatabase)
            {
                var DietExists = Diets.Any(Diet =>
                        Diet.Id == DietInDatabase.Id &&
                        Diet.Name == DietInDatabase.Name &&
                        Diet.Duration == DietInDatabase.Duration &&
                        Diet.Description == DietInDatabase.Description);

                Assert.True(
                    DietExists,
                    $"Diet with Id {DietInDatabase.Id} doesn't exist");
            }
        }

        [Test]
        public void GivenNoDietsExist_WhenGettingAllDiets_ReturnsEmptyCollection()
        {
            DietRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(new List<Diet>());

            var Diets = DietService.GetAll();

            Assert.AreEqual(0, Diets.Count());
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingADiet_ReturnsTheDiet()
        {
            var expectedDiet = DietsInDatabase.First();

            var Diet = DietService.Get(expectedDiet.Id);

            Assert.AreEqual(expectedDiet.Id, Diet.Id);
            Assert.AreEqual(expectedDiet.Name, Diet.Name);
            Assert.AreEqual(expectedDiet.Duration, Diet.Duration);
            Assert.AreEqual(expectedDiet.Description, Diet.Description);
        }
        #endregion

        private Mock<IDietRepository> SetUpDietRepositoryMock()
        {
            var DietRepositoryMock = new Mock<IDietRepository>();

            DietRepositoryMock.Setup(mock => mock.Add(It.IsAny<Diet>()));

            DietRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(DietsInDatabase);

            DietRepositoryMock
                .Setup(mock => mock.Get(DietsInDatabase.First().Id))
                .Returns(DietsInDatabase.First());

            return DietRepositoryMock;
        }
    }
}