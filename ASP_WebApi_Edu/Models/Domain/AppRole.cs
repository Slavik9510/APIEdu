using Microsoft.AspNetCore.Identity;

namespace ASP_WebApi_Edu.Models.Domain
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
