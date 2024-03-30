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

namespace Workout_Web.Tests.Services
{
    public class WorkoutServiceTests
    {
        private WorkoutService WorkoutService;

        private Mock<IWorkoutRepository> WorkoutRepositoryMock;

        private readonly IEnumerable<Workout> WorkoutsInDatabase;

        public WorkoutServiceTests()
        {
            WorkoutsInDatabase = new[]
            {
                new Workout(1, "new Workout 1", "10min", "Wow mnogo trudno"),
                new Workout(2, "new Workout 2", "101min", "Wow mnogo lesno"),
                new Workout(3, "new Workout 3", "1023min", "Wow mnogo qko")
            };
        }

        [SetUp]
        public void SetUp()
        {
            WorkoutRepositoryMock = SetUpWorkoutRepositoryMock();

            WorkoutService = new WorkoutService(WorkoutRepositoryMock.Object);
        }

        #region Add
        [Test]
        public void GivenValidWorkout_WhenAddingAWorkout_TheWorkoutIsAdded()
        {

            var Workout = new CreateWorkoutViewModel()
            {
                Name = "Workout",
                Duration = "10min",
                Place = "Wow mnogo trudno"
            };
            WorkoutService.Add(Workout);

            WorkoutRepositoryMock.Verify(
                mock => mock.Add(It.Is<Workout>(WorkoutEntity =>
                    WorkoutEntity.Name == Workout.Name &&
                    WorkoutEntity.Duration == Workout.Duration &&
                    WorkoutEntity.Place == Workout.Place)),
                Times.Once);
        }
        #endregion

        #region GetAll
        [Test]
        public void GivenWorkoutsExist_WhenGettingAllWorkouts_AllWorkoutsAreReturned()
        {
            var Workouts = WorkoutService.GetAll();

            Assert.AreEqual(
                WorkoutsInDatabase.Count(),
                Workouts.Count(),
                "Workouts count different than expected");

            foreach (var WorkoutInDatabase in WorkoutsInDatabase)
            {
                var WorkoutExists = Workouts.Any(Workout =>
                        Workout.Id == WorkoutInDatabase.Id &&
                        Workout.Name == WorkoutInDatabase.Name &&
                        Workout.Duration == WorkoutInDatabase.Duration &&
                        Workout.Place == WorkoutInDatabase.Place);

                Assert.True(
                    WorkoutExists,
                    $"Workout with Id {WorkoutInDatabase.Id} doesn't exist");
            }
        }

        [Test]
        public void GivenNoWorkoutsExist_WhenGettingAllWorkouts_ReturnsEmptyCollection()
        {
            WorkoutRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(new List<Workout>());

            var Workouts = WorkoutService.GetAll();

            Assert.AreEqual(0, Workouts.Count());
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingAWorkout_ReturnsTheWorkout()
        {
            var expectedWorkout = WorkoutsInDatabase.First();

            var Workout = WorkoutService.Get(expectedWorkout.Id);

            Assert.AreEqual(expectedWorkout.Id, Workout.Id);
            Assert.AreEqual(expectedWorkout.Name, Workout.Name);
            Assert.AreEqual(expectedWorkout.Duration, Workout.Duration);
            Assert.AreEqual(expectedWorkout.Place, Workout.Place);
        }
        #endregion

        private Mock<IWorkoutRepository> SetUpWorkoutRepositoryMock()
        {
            var WorkoutRepositoryMock = new Mock<IWorkoutRepository>();

            WorkoutRepositoryMock.Setup(mock => mock.Add(It.IsAny<Workout>()));

            WorkoutRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(WorkoutsInDatabase);

            WorkoutRepositoryMock
                .Setup(mock => mock.Get(WorkoutsInDatabase.First().Id))
                .Returns(WorkoutsInDatabase.First());

            return WorkoutRepositoryMock;
        }
    }
}