using Microsoft.EntityFrameworkCore;
using Moq;
using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories;
using Microsoft.EntityFrameworkCore;
using Products_Web.Data;

namespace Products_Web.Tests.Repositories
{
    public class PushUpRepositoryTests
    {
        private PushUpRepository PushUpRepository;

        private ApplicationContext applicationContext;

        [SetUp]
        public void SetUp()
        {
            applicationContext = SetUpApplicationContext();
            PushUpRepository = new PushUpRepository(applicationContext);
        }

        [TearDown]
        public void TearDown()
        {
            applicationContext.Database.EnsureDeleted();
        }

        #region Add
        [Test]
        public void GivenAPushUp_WhenAddingAPushUp_AddsIt()
        {
            var PushUp = new PushUp("new PushUp", "10min", "Wow mnogo trudno");

            PushUpRepository.Add(PushUp);

            var createdPushUp = applicationContext.PushUps.LastOrDefault();

            Assert.AreEqual(PushUp, createdPushUp, "PushUp is different than expected");
        }

        [Test]
        public void GivenNullPushUp_WhenAddingAPushUp_Throws()
        {
            var exception = Assert.Throws<ArgumentException>(() => PushUpRepository.Add(null));

            Assert.AreEqual(
                "PushUp can't be null!",
                exception.Message,
                "Exception message is different than expected");
        }
        #endregion

        #region GetAll
        [Test]
        public void WhenGettingAll_ReturnsAllPushUps()
        {
            var expectedPushUps = SeedPushUps();

            var PushUps = PushUpRepository.GetAll();

            Assert.AreEqual(expectedPushUps, PushUps);
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingAPushUp_ReturnsThePushUp()
        {
            var expectedPushUps = SeedPushUps();
            var expectedPushUp = expectedPushUps.First();

            var PushUp = PushUpRepository.Get(expectedPushUp.Id);

            Assert.AreEqual(expectedPushUp, PushUp, "PushUp is different than expected");
        }

        [Test]
        public void GivenNonExistingId_WhenGettingAPushUp_ReturnsThePushUp()
        {
            SeedPushUps();
            var nonExistingId = -1;

            var PushUp = PushUpRepository.Get(nonExistingId);

            Assert.Null(PushUp);
        }
        #endregion

        private IEnumerable<PushUp> SeedPushUps()
        {
            var PushUps = new[]
            {
                  new PushUp(1, "PushUp 1", "10min", "Wow mnogo trudno"),
                  new PushUp(2, "PushUp 2", "101min", "Wow mnogo lesno"),
                  new PushUp(3, "PushUp 3", "1032min", "Wow baba mi pochina")
            };
            applicationContext.PushUps.AddRange(PushUps);
            applicationContext.SaveChanges();

            return PushUps;
        }
        private ApplicationContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UnitTestsDb");

            return new ApplicationContext(options.Options);
        }
    }
}
