using ASP_WebApi_Edu.Models.Domain;

namespace ASP_WebApi_Edu.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
