using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Products_Web.Data.Entities;
using Products_Web.Models.Product;

namespace Products_Web.Repositories.Interfaces
{
    public interface ISquatRepository
    {
        void Add(Squat Squat);

        IEnumerable<Squat> GetAll();

        void Delete(int id);

        void Edit(Squat Squat);
        //void Edit(Edit"Product"ViewModel product);

        Squat Get(int id);
    }
}
