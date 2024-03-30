using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Products_Web.Data.Entities;
using Products_Web.Models.Product;

namespace Products_Web.Repositories.Interfaces
{
    public interface ITrainerRepository
    {
        void Add(Trainer trainer);

        IEnumerable<Trainer> GetAll();

        void Delete(int id);

        void Edit(Trainer trainer);
        //void Edit(Edit"Product"ViewModel product);

        Trainer Get(int id);
    }
}
