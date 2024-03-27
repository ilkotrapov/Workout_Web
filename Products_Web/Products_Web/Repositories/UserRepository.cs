using Products_Web.Data;
using Products_Web.Models.User;
using Products_Web.Repositories.Interfaces;

namespace Products_Web.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext dbContext;

        public UserRepository(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<UserViewModel> GetAll()
        {
            var userEntities = dbContext.Users.ToList().Select(userEntity =>
            {
                var userRole = dbContext.UserRoles.FirstOrDefault(userRoleEntity => userRoleEntity.UserId == userEntity.Id);
                if (userRole is null)
                {
                    return null;
                }

                var role = dbContext.Roles.First(roleEntity => userEntity.Id == userRole.RoleId);

                return new UserViewModel(userEntity.Id,
                                         userEntity.Email,
                                         userEntity.UserName,
                                         role.Name);
            })
            .Where(user => user != null);
            return null;
        }


    }
}
