using Microsoft.EntityFrameworkCore;
using Moq;
using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories;
using Microsoft.EntityFrameworkCore;
using Products_Web.Data;

namespace Products_Web.Tests.Repositories
{
    public class SquatRepositoryTests
    {
        private SquatRepository SquatRepository;

        private ApplicationContext applicationContext;

        [SetUp]
        public void SetUp()
        {
            applicationContext = SetUpApplicationContext();
            SquatRepository = new SquatRepository(applicationContext);
        }

        [TearDown]
        public void TearDown()
        {
            applicationContext.Database.EnsureDeleted();
        }

        #region Add
        [Test]
        public void GivenASquat_WhenAddingASquat_AddsIt()
        {
            var Squat = new Squat("new Squat", "10min", "Wow mnogo trudno");

            SquatRepository.Add(Squat);

            var createdSquat = applicationContext.Squats.LastOrDefault();

            Assert.AreEqual(Squat, createdSquat, "Squat is different than expected");
        }

        [Test]
        public void GivenNullSquat_WhenAddingASquat_Throws()
        {
            var exception = Assert.Throws<ArgumentException>(() => SquatRepository.Add(null));

            Assert.AreEqual(
                "Squat can't be null!",
                exception.Message,
                "Exception message is different than expected");
        }
        #endregion

        #region GetAll
        [Test]
        public void WhenGettingAll_ReturnsAllSquats()
        {
            var expectedSquats = SeedSquats();

            var Squats = SquatRepository.GetAll();

            Assert.AreEqual(expectedSquats, Squats);
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingASquat_ReturnsTheSquat()
        {
            var expectedSquats = SeedSquats();
            var expectedSquat = expectedSquats.First();

            var Squat = SquatRepository.Get(expectedSquat.Id);

            Assert.AreEqual(expectedSquat, Squat, "Squat is different than expected");
        }

        [Test]
        public void GivenNonExistingId_WhenGettingASquat_ReturnsTheSquat()
        {
            SeedSquats();
            var nonExistingId = -1;

            var Squat = SquatRepository.Get(nonExistingId);

            Assert.Null(Squat);
        }
        #endregion

        private IEnumerable<Squat> SeedSquats()
        {
            var Squats = new[]
            {
                  new Squat(1, "Squat 1", "10min", "Wow mnogo trudno"),
                  new Squat(2, "Squat 2", "101min", "Wow mnogo lesno"),
                  new Squat(3, "Squat 3", "1032min", "Wow baba mi pochina")
            };
            applicationContext.Squats.AddRange(Squats);
            applicationContext.SaveChanges();

            return Squats;
        }
        private ApplicationContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UnitTestsDb");

            return new ApplicationContext(options.Options);
        }
    }
}
