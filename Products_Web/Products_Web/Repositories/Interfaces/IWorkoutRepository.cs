using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Products_Web.Data.Entities;
using Products_Web.Models.Product;

namespace Products_Web.Repositories.Interfaces
{
    public interface IWorkoutRepository
    {
        void Add(Workout workout);

        IEnumerable<Workout> GetAll();

        void Delete(int id);

        void Edit(Workout workout);
        //void Edit(Edit"Product"ViewModel product);

        Workout Get(int id);
    }
}
