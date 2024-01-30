﻿using ASP_WebApi_Edu.Models.Domain;
using ASP_WebApi_Edu.Models.DTO;

namespace ASP_WebApi_Edu.Interfaces
{
    public interface IUserRepository
    {
        void Update(User user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<User?>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<IEnumerable<MemberDto?>> GetMembersAsync();
        Task<MemberDto?> GetMemberAsync(string username);
    }
}
