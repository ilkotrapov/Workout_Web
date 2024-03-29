using Products_Web.Data.Entities;
using Products_Web.Models.Product;
using Products_Web.Models.Workout;

namespace Products_Web.Services.Interfaces
{
    public interface IWorkoutService
    {
        void Add(CreateWorkoutViewModel workout);

        IEnumerable<WorkoutViewModel> GetAll();

        void Delete(int id);

        void Edit(EditWorkoutViewModel workout);

        WorkoutViewModel Get(int id);

        //ToDo: Get by Id
    }
}
