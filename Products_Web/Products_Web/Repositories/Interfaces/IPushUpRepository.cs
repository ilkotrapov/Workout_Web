using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Products_Web.Data.Entities;
using Products_Web.Models.Product;

namespace Products_Web.Repositories.Interfaces
{
    public interface IPushUpRepository
    {
        void Add(PushUp pushup);

        IEnumerable<PushUp> GetAll();

        void Delete(int id);

        void Edit(PushUp pushup);
        //void Edit(Edit"Product"ViewModel product);

        PushUp Get(int id);
    }
}
