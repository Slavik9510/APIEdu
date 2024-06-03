using Microsoft.AspNetCore.Identity;

namespace ASP_WebApi_Edu.Models.Domain
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}
