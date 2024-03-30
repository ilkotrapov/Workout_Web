using Microsoft.EntityFrameworkCore;
using Moq;
using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories;
using Microsoft.EntityFrameworkCore;
using Products_Web.Data;

namespace Products_Web.Tests.Repositories
{
    public class TrainerRepositoryTests
    {
        private TrainerRepository TrainerRepository;

        private ApplicationContext applicationContext;

        [SetUp]
        public void SetUp()
        {
            applicationContext = SetUpApplicationContext();
            TrainerRepository = new TrainerRepository(applicationContext);
        }

        [TearDown]
        public void TearDown()
        {
            applicationContext.Database.EnsureDeleted();
        }

        #region Add
        [Test]
        public void GivenATrainer_WhenAddingATrainer_AddsIt()
        {
            var Trainer = new Trainer("new Trainer", "10min", "Wow mnogo trudno");

            TrainerRepository.Add(Trainer);

            var createdTrainer = applicationContext.Trainers.LastOrDefault();

            Assert.AreEqual(Trainer, createdTrainer, "Trainer is different than expected");
        }

        [Test]
        public void GivenNullTrainer_WhenAddingATrainer_Throws()
        {
            var exception = Assert.Throws<ArgumentException>(() => TrainerRepository.Add(null));

            Assert.AreEqual(
                "Trainer can't be null!",
                exception.Message,
                "Exception message is different than expected");
        }
        #endregion

        #region GetAll
        [Test]
        public void WhenGettingAll_ReturnsAllTrainers()
        {
            var expectedTrainers = SeedTrainers();

            var Trainers = TrainerRepository.GetAll();

            Assert.AreEqual(expectedTrainers, Trainers);
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingATrainer_ReturnsTheTrainer()
        {
            var expectedTrainers = SeedTrainers();
            var expectedTrainer = expectedTrainers.First();

            var Trainer = TrainerRepository.Get(expectedTrainer.Id);

            Assert.AreEqual(expectedTrainer, Trainer, "Trainer is different than expected");
        }

        [Test]
        public void GivenNonExistingId_WhenGettingATrainer_ReturnsTheTrainer()
        {
            SeedTrainers();
            var nonExistingId = -1;

            var Trainer = TrainerRepository.Get(nonExistingId);

            Assert.Null(Trainer);
        }
        #endregion

        private IEnumerable<Trainer> SeedTrainers()
        {
            var Trainers = new[]
            {
                  new Trainer(1, "Trainer 1", "10min", "Wow mnogo trudno"),
                  new Trainer(2, "Trainer 2", "101min", "Wow mnogo lesno"),
                  new Trainer(3, "Trainer 3", "1032min", "Wow baba mi pochina")
            };
            applicationContext.Trainers.AddRange(Trainers);
            applicationContext.SaveChanges();

            return Trainers;
        }
        private ApplicationContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UnitTestsDb");

            return new ApplicationContext(options.Options);
        }
    }
}
