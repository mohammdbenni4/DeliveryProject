using System.Security.Claims;
using Domain.Models.Security;
using Elkood.Application.Results;
using Microsoft.AspNetCore.Identity;

namespace Domain.Interfaces;

public interface IUserRepository : IRepository
{
    Task<Result<(string accessToken,string RefreshToken)>> LogIn<TUser>(string email,string password) where TUser : User;
    Task<Result<(string accessToken, TUser user)>> LogInByPhoneNumber<TUser>(string phoneNumber,string password) where TUser : User;
    Task<IdentityResult> AddWithRole(User user, string password, string? roleName=null);
    Task<IdentityResult> TryModifyPassword(User user, string? newPassword);
    Task<IdentityResult> TryModifyRole(User user, string roleName);
    Task<bool> ChangeBlockStatus<TUser>(Guid id) where TUser : User;
    Task<Result<string>> RefreshToken<TUser>(Guid id, string refreshToken) where TUser : User;
    Task<string> GetAccessToken(User user,params Claim[] extra);
    Task<User?> GetUserById<TUser>(Guid id) where TUser : User;
    Task<IdentityResult> RemoveAllRoles(User user);
    
}