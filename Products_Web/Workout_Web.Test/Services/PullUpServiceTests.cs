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
using PullUps_Web.Services;

namespace PullUp_Web.Tests.Services
{
    public class PullUpServiceTests
    {
        private PullUpService PullUpService;

        private Mock<IPullUpRepository> PullUpRepositoryMock;

        private readonly IEnumerable<PullUp> PullUpsInDatabase;

        public PullUpServiceTests()
        {
            PullUpsInDatabase = new[]
            {
                new PullUp(1, "new PullUp 1", "10min", "Wow mnogo trudno"),
                new PullUp(2, "new PullUp 2", "101min", "Wow mnogo lesno"),
                new PullUp(3, "new PullUp 3", "1023min", "Wow mnogo qko")
            };
        }

        [SetUp]
        public void SetUp()
        {
            PullUpRepositoryMock = SetUpPullUpRepositoryMock();

            PullUpService = new PullUpService(PullUpRepositoryMock.Object);
        }

        #region Add
        [Test]
        public void GivenValidPullUp_WhenAddingAPullUp_ThePullUpIsAdded()
        {

            var PullUp = new CreatePullUpViewModel()
            {
                Name = "PullUp",
                Difficulty = "10min",
                Type = "Wow mnogo trudno"
            };
            PullUpService.Add(PullUp);

            PullUpRepositoryMock.Verify(
                mock => mock.Add(It.Is<PullUp>(PullUpEntity =>
                    PullUpEntity.Name == PullUp.Name &&
                    PullUpEntity.Difficulty == PullUp.Difficulty &&
                    PullUpEntity.Type == PullUp.Type)),
                Times.Once);
        }
        #endregion

        #region GetAll
        [Test]
        public void GivenPullUpsExist_WhenGettingAllPullUps_AllPullUpsAreReturned()
        {
            var PullUps = PullUpService.GetAll();

            Assert.AreEqual(
                PullUpsInDatabase.Count(),
                PullUps.Count(),
                "PullUps count different than expected");

            foreach (var PullUpInDatabase in PullUpsInDatabase)
            {
                var PullUpExists = PullUps.Any(PullUp =>
                        PullUp.Id == PullUpInDatabase.Id &&
                        PullUp.Name == PullUpInDatabase.Name &&
                        PullUp.Difficulty == PullUpInDatabase.Difficulty &&
                        PullUp.Type == PullUpInDatabase.Type);

                Assert.True(
                    PullUpExists,
                    $"PullUp with Id {PullUpInDatabase.Id} doesn't exist");
            }
        }

        [Test]
        public void GivenNoPullUpsExist_WhenGettingAllPullUps_ReturnsEmptyCollection()
        {
            PullUpRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(new List<PullUp>());

            var PullUps = PullUpService.GetAll();

            Assert.AreEqual(0, PullUps.Count());
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingAPullUp_ReturnsThePullUp()
        {
            var expectedPullUp = PullUpsInDatabase.First();

            var PullUp = PullUpService.Get(expectedPullUp.Id);

            Assert.AreEqual(expectedPullUp.Id, PullUp.Id);
            Assert.AreEqual(expectedPullUp.Name, PullUp.Name);
            Assert.AreEqual(expectedPullUp.Difficulty, PullUp.Difficulty);
            Assert.AreEqual(expectedPullUp.Type, PullUp.Type);
        }
        #endregion

        private Mock<IPullUpRepository> SetUpPullUpRepositoryMock()
        {
            var PullUpRepositoryMock = new Mock<IPullUpRepository>();

            PullUpRepositoryMock.Setup(mock => mock.Add(It.IsAny<PullUp>()));

            PullUpRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(PullUpsInDatabase);

            PullUpRepositoryMock
                .Setup(mock => mock.Get(PullUpsInDatabase.First().Id))
                .Returns(PullUpsInDatabase.First());

            return PullUpRepositoryMock;
        }
    }
}