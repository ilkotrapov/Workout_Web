using Products_Web.Data.Entities;
using Products_Web.Models.Product;

namespace Products_Web.Services.Interfaces
{
    public interface IPullUpService
    {
        void Add(CreatePullUpViewModel PushUp);

        IEnumerable<PullUpViewModel> GetAll();

        void Delete(int id);

        void Edit(EditPullUpViewModel PullUp);

        PullUpViewModel Get(int id);

        //ToDo: Get by Id
    }
}
