using Microsoft.EntityFrameworkCore;
using Moq;
using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories;
using Microsoft.EntityFrameworkCore;
using Products_Web.Data;

namespace Products_Web.Tests.Repositories
{
    public class PullUpRepositoryTests
    {
        private PullUpRepository PullUpRepository;

        private ApplicationContext applicationContext;

        [SetUp]
        public void SetUp()
        {
            applicationContext = SetUpApplicationContext();
            PullUpRepository = new PullUpRepository(applicationContext);
        }

        [TearDown]
        public void TearDown()
        {
            applicationContext.Database.EnsureDeleted();
        }

        #region Add
        [Test]
        public void GivenAPullUp_WhenAddingAPullUp_AddsIt()
        {
            var PullUp = new PullUp("new PullUp", "10min", "Wow mnogo trudno");

            PullUpRepository.Add(PullUp);

            var createdPullUp = applicationContext.PullUps.LastOrDefault();

            Assert.AreEqual(PullUp, createdPullUp, "PullUp is different than expected");
        }

        [Test]
        public void GivenNullPullUp_WhenAddingAPullUp_Throws()
        {
            var exception = Assert.Throws<ArgumentException>(() => PullUpRepository.Add(null));

            Assert.AreEqual(
                "PullUp can't be null!",
                exception.Message,
                "Exception message is different than expected");
        }
        #endregion

        #region GetAll
        [Test]
        public void WhenGettingAll_ReturnsAllPullUps()
        {
            var expectedPullUps = SeedPullUps();

            var PullUps = PullUpRepository.GetAll();

            Assert.AreEqual(expectedPullUps, PullUps);
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingAPullUp_ReturnsThePullUp()
        {
            var expectedPullUps = SeedPullUps();
            var expectedPullUp = expectedPullUps.First();

            var PullUp = PullUpRepository.Get(expectedPullUp.Id);

            Assert.AreEqual(expectedPullUp, PullUp, "PullUp is different than expected");
        }

        [Test]
        public void GivenNonExistingId_WhenGettingAPullUp_ReturnsThePullUp()
        {
            SeedPullUps();
            var nonExistingId = -1;

            var PullUp = PullUpRepository.Get(nonExistingId);

            Assert.Null(PullUp);
        }
        #endregion

        private IEnumerable<PullUp> SeedPullUps()
        {
            var PullUps = new[]
            {
                  new PullUp(1, "PullUp 1", "10min", "Wow mnogo trudno"),
                  new PullUp(2, "PullUp 2", "101min", "Wow mnogo lesno"),
                  new PullUp(3, "PullUp 3", "1032min", "Wow baba mi pochina")
            };
            applicationContext.PullUps.AddRange(PullUps);
            applicationContext.SaveChanges();

            return PullUps;
        }
        private ApplicationContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UnitTestsDb");

            return new ApplicationContext(options.Options);
        }
    }
}
