using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Products_Web.Data.Entities;
using Products_Web.Models.Product;

namespace Products_Web.Repositories.Interfaces
{
    public interface IDietRepository
    {
        void Add(Diet diet);

        IEnumerable<Diet> GetAll();

        void Delete(int id);

        void Edit(Diet diet);
        //void Edit(EditProductViewModel product);

        Diet Get(int id);
    }
}
