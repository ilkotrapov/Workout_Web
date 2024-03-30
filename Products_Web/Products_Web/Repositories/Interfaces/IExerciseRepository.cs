using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Products_Web.Data.Entities;
using Products_Web.Models.Product;

namespace Products_Web.Repositories.Interfaces
{
    public interface IExerciseRepository
    {
        void Add(Exercise exercise);

        IEnumerable<Exercise> GetAll();

        void Delete(int id);

        void Edit(Exercise exercise);
        //void Edit(EditProductViewModel product);

        Exercise Get(int id);
    }
}
