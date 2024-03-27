using Products_Web.Models.User;

namespace Products_Web.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserViewModel> GetAll();
    }
}

