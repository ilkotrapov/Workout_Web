using Products_Web.Models.User;

namespace Products_Web.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAll();

        //Task<IEnumerable<UserViewModel>> GetAll2();
    }
}
