using Products_Web.Data.Entities;
using Products_Web.Models.Product;

namespace Products_Web.Services.Interfaces
{
    public interface IPushUpService
    {
        void Add(CreatePushUpViewModel pushup);

        IEnumerable<PushUpViewModel> GetAll();

        void Delete(int id);

        void Edit(EditPushUpViewModel pushup);

        PushUpViewModel Get(int id);

        //ToDo: Get by Id
    }
}
