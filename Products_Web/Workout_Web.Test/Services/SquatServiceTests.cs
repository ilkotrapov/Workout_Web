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
using Squats_Web.Services;

namespace Squat_Web.Tests.Services
{
    public class SquatServiceTests
    {
        private SquatService SquatService;

        private Mock<ISquatRepository> SquatRepositoryMock;

        private readonly IEnumerable<Squat> SquatsInDatabase;

        public SquatServiceTests()
        {
            SquatsInDatabase = new[]
            {
                new Squat(1, "new Squat 1", "10min", "Wow mnogo trudno"),
                new Squat(2, "new Squat 2", "101min", "Wow mnogo lesno"),
                new Squat(3, "new Squat 3", "1023min", "Wow mnogo qko")
            };
        }

        [SetUp]
        public void SetUp()
        {
            SquatRepositoryMock = SetUpSquatRepositoryMock();

            SquatService = new SquatService(SquatRepositoryMock.Object);
        }

        #region Add
        [Test]
        public void GivenValidSquat_WhenAddingASquat_TheSquatIsAdded()
        {

            var Squat = new CreateSquatViewModel()
            {
                Name = "Squat",
                Difficulty = "10min",
                Type = "Wow mnogo trudno"
            };
            SquatService.Add(Squat);

            SquatRepositoryMock.Verify(
                mock => mock.Add(It.Is<Squat>(SquatEntity =>
                    SquatEntity.Name == Squat.Name &&
                    SquatEntity.Difficulty == Squat.Difficulty &&
                    SquatEntity.Type == Squat.Type)),
                Times.Once);
        }
        #endregion

        #region GetAll
        [Test]
        public void GivenSquatsExist_WhenGettingAllSquats_AllSquatsAreReturned()
        {
            var Squats = SquatService.GetAll();

            Assert.AreEqual(
                SquatsInDatabase.Count(),
                Squats.Count(),
                "Squats count different than expected");

            foreach (var SquatInDatabase in SquatsInDatabase)
            {
                var SquatExists = Squats.Any(Squat =>
                        Squat.Id == SquatInDatabase.Id &&
                        Squat.Name == SquatInDatabase.Name &&
                        Squat.Difficulty == SquatInDatabase.Difficulty &&
                        Squat.Type == SquatInDatabase.Type);

                Assert.True(
                    SquatExists,
                    $"Squat with Id {SquatInDatabase.Id} doesn't exist");
            }
        }

        [Test]
        public void GivenNoSquatsExist_WhenGettingAllSquats_ReturnsEmptyCollection()
        {
            SquatRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(new List<Squat>());

            var Squats = SquatService.GetAll();

            Assert.AreEqual(0, Squats.Count());
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingASquat_ReturnsTheSquat()
        {
            var expectedSquat = SquatsInDatabase.First();

            var Squat = SquatService.Get(expectedSquat.Id);

            Assert.AreEqual(expectedSquat.Id, Squat.Id);
            Assert.AreEqual(expectedSquat.Name, Squat.Name);
            Assert.AreEqual(expectedSquat.Difficulty, Squat.Difficulty);
            Assert.AreEqual(expectedSquat.Type, Squat.Type);
        }
        #endregion

        private Mock<ISquatRepository> SetUpSquatRepositoryMock()
        {
            var SquatRepositoryMock = new Mock<ISquatRepository>();

            SquatRepositoryMock.Setup(mock => mock.Add(It.IsAny<Squat>()));

            SquatRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(SquatsInDatabase);

            SquatRepositoryMock
                .Setup(mock => mock.Get(SquatsInDatabase.First().Id))
                .Returns(SquatsInDatabase.First());

            return SquatRepositoryMock;
        }
    }
}