using Microsoft.EntityFrameworkCore;
using Moq;
using Products_Web.Data;
using Products_Web.Data.Entities;
using Products_Web.Repositories;
using Microsoft.EntityFrameworkCore;
using Products_Web.Data;

namespace Products_Web.Tests.Repositories
{
    public class WorkoutRepositoryTests
    {
        private WorkoutRepository WorkoutRepository;

        private ApplicationContext applicationContext;

        [SetUp]
        public void SetUp()
        {
            applicationContext = SetUpApplicationContext();
            WorkoutRepository = new WorkoutRepository(applicationContext);
        }

        [TearDown]
        public void TearDown()
        {
            applicationContext.Database.EnsureDeleted();
        }

        #region Add
        [Test]
        public void GivenAWorkout_WhenAddingAWorkout_AddsIt()
        {
            var Workout = new Workout("new Workout", "10min", "Wow mnogo trudno");

            WorkoutRepository.Add(Workout);

            var createdWorkout = applicationContext.Workouts.LastOrDefault();

            Assert.AreEqual(Workout, createdWorkout, "Workout is different than expected");
        }

        [Test]
        public void GivenNullWorkout_WhenAddingAWorkout_Throws()
        {
            var exception = Assert.Throws<ArgumentException>(() => WorkoutRepository.Add(null));

            Assert.AreEqual(
                "Workout can't be null!",
                exception.Message,
                "Exception message is different than expected");
        }
        #endregion

        #region GetAll
        [Test]
        public void WhenGettingAll_ReturnsAllWorkouts()
        {
            var expectedWorkouts = SeedWorkouts();

            var Workouts = WorkoutRepository.GetAll();

            Assert.AreEqual(expectedWorkouts, Workouts);
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingAWorkout_ReturnsTheWorkout()
        {
            var expectedWorkouts = SeedWorkouts();
            var expectedWorkout = expectedWorkouts.First();

            var Workout = WorkoutRepository.Get(expectedWorkout.Id);

            Assert.AreEqual(expectedWorkout, Workout, "Workout is different than expected");
        }

        [Test]
        public void GivenNonExistingId_WhenGettingAWorkout_ReturnsTheWorkout()
        {
            SeedWorkouts();
            var nonExistingId = -1;

            var Workout = WorkoutRepository.Get(nonExistingId);

            Assert.Null(Workout);
        }
        #endregion

        private IEnumerable<Workout> SeedWorkouts()
        {
            var Workouts = new[]
            {
                  new Workout(1, "Workout 1", "10min", "Wow mnogo trudno"),
                  new Workout(2, "Workout 2", "101min", "Wow mnogo lesno"),
                  new Workout(3, "Workout 3", "1032min", "Wow baba mi pochina")
            };
            applicationContext.Workouts.AddRange(Workouts);
            applicationContext.SaveChanges();

            return Workouts;
        }
        private ApplicationContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UnitTestsDb");

            return new ApplicationContext(options.Options);
        }
    }
}
