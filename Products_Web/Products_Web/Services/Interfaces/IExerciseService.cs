using Products_Web.Data.Entities;
using Products_Web.Models.Product;

namespace Products_Web.Services.Interfaces
{
    public interface IExerciseService
    {
        void Add(CreateExerciseViewModel exercise);

        IEnumerable<ExerciseViewModel> GetAll();

        void Delete(int id);

        void Edit(EditExerciseViewModel exercise);

        ExerciseViewModel Get(int id);

        //ToDo: Get by Id e ai de
    }
}
