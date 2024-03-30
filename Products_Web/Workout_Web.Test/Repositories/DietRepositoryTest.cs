using Microsoft.EntityFrameworkCore;
using Moq;
using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories;
using Microsoft.EntityFrameworkCore;
using Products_Web.Data;

namespace Products_Web.Tests.Repositories
{
    public class DietRepositoryTests
    {
        private DietRepository DietRepository;

        private ApplicationContext applicationContext;

        [SetUp]
        public void SetUp()
        {
            applicationContext = SetUpApplicationContext();
            DietRepository = new DietRepository(applicationContext);
        }

        [TearDown]
        public void TearDown()
        {
            applicationContext.Database.EnsureDeleted();
        }

        #region Add
        [Test]
        public void GivenADiet_WhenAddingADiet_AddsIt()
        {
            var diet = new Diet("new Diet", "10min", "Wow mnogo trudno");

            DietRepository.Add(diet);

            var createdDiet = applicationContext.Diets.LastOrDefault();

            Assert.AreEqual(diet, createdDiet, "Diet is different than expected");
        }

        [Test]
        public void GivenNullDiet_WhenAddingADiet_Throws()
        {
            var exception = Assert.Throws<ArgumentException>(() => DietRepository.Add(null));

            Assert.AreEqual(
                "Diet can't be null!",
                exception.Message,
                "Exception message is different than expected");
        }
        #endregion

        #region GetAll
        [Test]
        public void WhenGettingAll_ReturnsAllDiets()
        {
            var expectedDiets = SeedDiets();

            var diets = DietRepository.GetAll();

            Assert.AreEqual(expectedDiets, diets);
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingADiet_ReturnsTheDiet()
        {
            var expectedDiets = SeedDiets();
            var expectedDiet = expectedDiets.First();

            var Diet = DietRepository.Get(expectedDiet.Id);

            Assert.AreEqual(expectedDiet, Diet, "Diet is different than expected");
        }

        [Test]
        public void GivenNonExistingId_WhenGettingADiet_ReturnsTheDiet()
        {
            SeedDiets();
            var nonExistingId = -1;

            var Diet = DietRepository.Get(nonExistingId);

            Assert.Null(Diet);
        }
        #endregion

        private IEnumerable<Diet> SeedDiets()
        {
            var Diets = new[]
            {
                  new Diet(1, "Diet 1", "10min", "Wow mnogo trudno"),
                  new Diet(2, "Diet 2", "101min", "Wow mnogo lesno"),
                  new Diet(3, "Diet 3", "1032min", "Wow baba mi pochina")
            };
            applicationContext.Diets.AddRange(Diets);
            applicationContext.SaveChanges();

            return Diets;
        }
        private ApplicationContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UnitTestsDb");

            return new ApplicationContext(options.Options);
        }
    }
}
