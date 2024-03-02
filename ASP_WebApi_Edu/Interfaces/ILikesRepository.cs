using ASP_WebApi_Edu.Helpers;
using ASP_WebApi_Edu.Models.Domain;
using ASP_WebApi_Edu.Models.DTO;

namespace ASP_WebApi_Edu.Interfaces
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUserId, int targetUserId);
        Task<AppUser> GetUserWithLikes(int userId);
        Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams);
    }
}
