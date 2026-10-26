using Microsoft.AspNetCore.Identity;

namespace Product_Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
