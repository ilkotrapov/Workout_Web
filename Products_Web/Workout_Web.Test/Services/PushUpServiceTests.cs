using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workouts_Web.Services;
using Moq;
using Products_Web.Data.Entities;
using Products_Web.Models.Product;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services;
using Products_Web.Models.Workout;
using Workouts_Web.Services;
using PushUps_Web.Services;

namespace PushUp_Web.Tests.Services
{
    public class PushUpServiceTests
    {
        private PushUpService PushUpService;

        private Mock<IPushUpRepository> PushUpRepositoryMock;

        private readonly IEnumerable<PushUp> PushUpsInDatabase;

        public PushUpServiceTests()
        {
            PushUpsInDatabase = new[]
            {
                new PushUp(1, "new PushUp 1", "10min", "Wow mnogo trudno"),
                new PushUp(2, "new PushUp 2", "101min", "Wow mnogo lesno"),
                new PushUp(3, "new PushUp 3", "1023min", "Wow mnogo qko")
            };
        }

        [SetUp]
        public void SetUp()
        {
            PushUpRepositoryMock = SetUpPushUpRepositoryMock();

            PushUpService = new PushUpService(PushUpRepositoryMock.Object);
        }

        #region Add
        [Test]
        public void GivenValidPushUp_WhenAddingAPushUp_ThePushUpIsAdded()
        {

            var PushUp = new CreatePushUpViewModel()
            {
                Name = "PushUp",
                Difficulty = "10min",
                Type = "Wow mnogo trudno"
            };
            PushUpService.Add(PushUp);

            PushUpRepositoryMock.Verify(
                mock => mock.Add(It.Is<PushUp>(PushUpEntity =>
                    PushUpEntity.Name == PushUp.Name &&
                    PushUpEntity.Difficulty == PushUp.Difficulty &&
                    PushUpEntity.Type == PushUp.Type)),
                Times.Once);
        }
        #endregion

        #region GetAll
        [Test]
        public void GivenPushUpsExist_WhenGettingAllPushUps_AllPushUpsAreReturned()
        {
            var PushUps = PushUpService.GetAll();

            Assert.AreEqual(
                PushUpsInDatabase.Count(),
                PushUps.Count(),
                "PushUps count different than expected");

            foreach (var PushUpInDatabase in PushUpsInDatabase)
            {
                var PushUpExists = PushUps.Any(PushUp =>
                        PushUp.Id == PushUpInDatabase.Id &&
                        PushUp.Name == PushUpInDatabase.Name &&
                        PushUp.Difficulty == PushUpInDatabase.Difficulty &&
                        PushUp.Type == PushUpInDatabase.Type);

                Assert.True(
                    PushUpExists,
                    $"PushUp with Id {PushUpInDatabase.Id} doesn't exist");
            }
        }

        [Test]
        public void GivenNoPushUpsExist_WhenGettingAllPushUps_ReturnsEmptyCollection()
        {
            PushUpRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(new List<PushUp>());

            var PushUps = PushUpService.GetAll();

            Assert.AreEqual(0, PushUps.Count());
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingAPushUp_ReturnsThePushUp()
        {
            var expectedPushUp = PushUpsInDatabase.First();

            var PushUp = PushUpService.Get(expectedPushUp.Id);

            Assert.AreEqual(expectedPushUp.Id, PushUp.Id);
            Assert.AreEqual(expectedPushUp.Name, PushUp.Name);
            Assert.AreEqual(expectedPushUp.Difficulty, PushUp.Difficulty);
            Assert.AreEqual(expectedPushUp.Type, PushUp.Type);
        }
        #endregion

        private Mock<IPushUpRepository> SetUpPushUpRepositoryMock()
        {
            var PushUpRepositoryMock = new Mock<IPushUpRepository>();

            PushUpRepositoryMock.Setup(mock => mock.Add(It.IsAny<PushUp>()));

            PushUpRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(PushUpsInDatabase);

            PushUpRepositoryMock
                .Setup(mock => mock.Get(PushUpsInDatabase.First().Id))
                .Returns(PushUpsInDatabase.First());

            return PushUpRepositoryMock;
        }
    }
}