using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainers_Web.Services;
using Moq;
using Products_Web.Data.Entities;
using Products_Web.Models.Product;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services;

namespace Trainer_Web.Tests.Services
{
    public class TrainerServiceTests
    {
        private TrainerService TrainerService;

        private Mock<ITrainerRepository> TrainerRepositoryMock;

        private readonly IEnumerable<Trainer> TrainersInDatabase;

        public TrainerServiceTests()
        {
            TrainersInDatabase = new[]
            {
                new Trainer(1, "new Trainer 1", "10min", "Wow mnogo trudno"),
                new Trainer(2, "new Trainer 2", "101min", "Wow mnogo lesno"),
                new Trainer(3, "new Trainer 3", "1023min", "Wow mnogo qko")
            };
        }

        [SetUp]
        public void SetUp()
        {
            TrainerRepositoryMock = SetUpTrainerRepositoryMock();

            TrainerService = new TrainerService(TrainerRepositoryMock.Object);
        }

        #region Add
        [Test]
        public void GivenValidTrainer_WhenAddingATrainer_TheTrainerIsAdded()
        {

            var Trainer = new CreateTrainerViewModel()
            {
                Name = "Trainer",
                Email = "10min",
                Gym = "Wow mnogo trudno"
            };
            TrainerService.Add(Trainer);

            TrainerRepositoryMock.Verify(
                mock => mock.Add(It.Is<Trainer>(TrainerEntity =>
                    TrainerEntity.Name == Trainer.Name &&
                    TrainerEntity.Email == Trainer.Email &&
                    TrainerEntity.Gym == Trainer.Gym)),
                Times.Once);
        }
        #endregion

        #region GetAll
        [Test]
        public void GivenTrainersExist_WhenGettingAllTrainers_AllTrainersAreReturned()
        {
            var Trainers = TrainerService.GetAll();

            Assert.AreEqual(
                TrainersInDatabase.Count(),
                Trainers.Count(),
                "Trainers count different than expected");

            foreach (var TrainerInDatabase in TrainersInDatabase)
            {
                var TrainerExists = Trainers.Any(Trainer =>
                        Trainer.Id == TrainerInDatabase.Id &&
                        Trainer.Name == TrainerInDatabase.Name &&
                        Trainer.Email == TrainerInDatabase.Email &&
                        Trainer.Gym == TrainerInDatabase.Gym);

                Assert.True(
                    TrainerExists,
                    $"Trainer with Id {TrainerInDatabase.Id} doesn't exist");
            }
        }

        [Test]
        public void GivenNoTrainersExist_WhenGettingAllTrainers_ReturnsEmptyCollection()
        {
            TrainerRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(new List<Trainer>());

            var Trainers = TrainerService.GetAll();

            Assert.AreEqual(0, Trainers.Count());
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingATrainer_ReturnsTheTrainer()
        {
            var expectedTrainer = TrainersInDatabase.First();

            var Trainer = TrainerService.Get(expectedTrainer.Id);

            Assert.AreEqual(expectedTrainer.Id, Trainer.Id);
            Assert.AreEqual(expectedTrainer.Name, Trainer.Name);
            Assert.AreEqual(expectedTrainer.Email, Trainer.Email);
            Assert.AreEqual(expectedTrainer.Gym, Trainer.Gym);
        }
        #endregion

        private Mock<ITrainerRepository> SetUpTrainerRepositoryMock()
        {
            var TrainerRepositoryMock = new Mock<ITrainerRepository>();

            TrainerRepositoryMock.Setup(mock => mock.Add(It.IsAny<Trainer>()));

            TrainerRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(TrainersInDatabase);

            TrainerRepositoryMock
                .Setup(mock => mock.Get(TrainersInDatabase.First().Id))
                .Returns(TrainersInDatabase.First());

            return TrainerRepositoryMock;
        }
    }
}