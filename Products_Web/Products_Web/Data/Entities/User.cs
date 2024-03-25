using Microsoft.AspNetCore.Identity;

namespace Products_Web.Data.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
