using ASP_WebApi_Edu.Helpers;
using ASP_WebApi_Edu.Models.Domain;
using ASP_WebApi_Edu.Models.DTO;

namespace ASP_WebApi_Edu.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser?>> GetUsersAsync();
        Task<AppUser?> GetUserByIdAsync(int id);
        Task<AppUser?> GetUserByUsernameAsync(string username);
        Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
        Task<MemberDto?> GetMemberAsync(string username);
    }
}
