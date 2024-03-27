using Products_Web.Models.User;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services.Interfaces;

namespace Products_Web.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        //private readonly UserManager<User> userManager;


        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            // this.userManager = userManager;
        }

        public IEnumerable<UserViewModel> GetAll()
            => userRepository.GetAll();

        /*public async Task<IEnumerable<UserViewModel>> GetAll2()
        {
            var users = new List<UserViewModel>();

            var userRoles = Enum.GetValues(typeof(Roles));
            foreach (var role in userRoles)
            {
                var usersInRoleEntities = await userManager.GetUsersInRoleAsync(role.ToString());
                var usersInRole = usersInRoleEntities.Select(user => new UserViewModel(user.Id, user.Email, user.Name, role.ToString()));

                users.AddRange(usersInRole);
            }
            return users;
        }*/
    }
}
