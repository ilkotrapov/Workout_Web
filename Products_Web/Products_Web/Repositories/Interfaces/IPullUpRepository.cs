using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Products_Web.Data.Entities;
using Products_Web.Models.Product;

namespace Products_Web.Repositories.Interfaces
{
    public interface IPullUpRepository
    {
        void Add(PullUp PullUp);

        IEnumerable<PullUp> GetAll();

        void Delete(int id);

        void Edit(PullUp PullUp);
        //void Edit(EditProductViewModel product);

        PullUp Get(int id);
    }
}
