using System.Security.Claims;
using Application.Core;
using Domain.Error;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Security;
using Elkood.Application.Results;
using Elkood.Application.Security.Claims;
using Elkood.Application.Security.JWT;
using Elkood.Domain.Repository;
using Elkood.Identity.Mangers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Persistence.Repositories;

public class UserRepository : Repository , IUserRepository
{
    private readonly ElUserManager<User> _elUserManager;
    private readonly IJwtBearerAuthentication _jwt;
        
    public UserRepository(IApplicationDbContext context
        , IOptions<ElRepositoryOptions> options
        , ElUserManager<User> elUserManager
        , IJwtBearerAuthentication jwt) : base(context, options)
    {
        _elUserManager = elUserManager;
        _jwt = jwt;
    }

    public async Task<Result<(string accessToken, string RefreshToken)>> LogIn<TUser>(string email, string password) where TUser : User
    {
        var user = await Query<TUser>().FirstOrDefaultAsync(user => user.NormalizedEmail == email.ToUpper());

        if (user == null)
            return Result<(string accessToken,string RefreshToken)>.Failure(DomainError.User.NotFound);

        if (!await _elUserManager.CheckPasswordAsync(user, password))
            return Result<(string accessToken,string RefreshToken)>.Failure(DomainError.User.EmailOrPasswordWrong);

        if (user.DateBlocked.HasValue)
            return Result<(string accessToken,string RefreshToken)>.Failure(DomainError.User.Blocked);
        
        var accessToken = await GetAccessToken(user);
        return Result<(string accessToken,string RefreshToken)>.Success(new ValueTuple<string, string>(accessToken,user.PasswordHash!));
    }

    public async Task<Result<(string accessToken, TUser user)>> LogInByPhoneNumber<TUser>(string phoneNumber, string password) where TUser : User
    {
        var user = await Query<TUser>().FirstAsync(user => user.PhoneNumber == phoneNumber);

        if (user == null)
            return Result<(string accessToken, TUser user)>.Failure(DomainError.User.NotFound);

        if (!await _elUserManager.CheckPasswordAsync(user, password))
            return Result<(string accessToken, TUser user)>.Failure(DomainError.User.EmailOrPasswordWrong);

        if (user.DateBlocked.HasValue)
            return Result<(string accessToken, TUser user)>.Failure(DomainError.User.Blocked);
        
        var accessToken = await GetAccessToken(user);
        return Result<(string accessToken, TUser user)>.Success(new ValueTuple<string, TUser>(accessToken, user));

    }

   

    public async Task<IdentityResult> AddWithRole(User user, string password, string? roleName = null)
    {
        var identityResult = await _elUserManager.CreateAsync(user, password);
        if (!identityResult.Succeeded) return identityResult;
    
        if(roleName != null)
            return await _elUserManager.AddToRoleAsync(user, roleName);
        
        return IdentityResult.Success;
    }

    public async Task<IdentityResult> TryModifyPassword(User user, string? newPassword)
    {
        if (string.IsNullOrEmpty(newPassword)) return IdentityResult.Success;
    
        await _elUserManager.RemovePasswordAsync(user);
        return await _elUserManager.AddPasswordAsync(user, newPassword!);
    }

    public async Task<IdentityResult> TryModifyRole(User user, string roleName)
    {
        var roles = await _elUserManager.GetRolesAsync(user);
        if (roles.Contains(roleName))
            return IdentityResult.Success;
    
        await _elUserManager.RemoveFromRolesAsync(user, roles);
        return await _elUserManager.AddToRoleAsync(user, roleName);
    }

    public async Task<bool> ChangeBlockStatus<TUser>(Guid id) where TUser : User
    {
        var user = await TrackingQuery<TUser>().Where(e => e.Id == id).FirstAsync();
        if (user.DateBlocked.HasValue)
        {
            await _elUserManager.UnBlockAsync(user);
            return false;
        }
    
        await _elUserManager.BlockAsync(user);
        return true;
    }

    public async Task<Result<string>> RefreshToken<TUser>(Guid id, string refreshToken) where TUser : User
    {
        var user = await Query<TUser>().FirstAsync(user => user.Id == id);
        
        if (user is null || user.DateDeleted.HasValue)
            return Result<string>.Failure(DomainError.User.NotFound);
    
        if (user.DateBlocked.HasValue)
            return Result<string>.Failure(DomainError.User.Blocked);
    
        if (!user.PasswordHash!.Equals(refreshToken))
            return Result<string>.Failure(DomainError.User.InvalidRefreshToken);
    
        var accessToken = await GetAccessToken(user);
        return Result<string>.Success(accessToken);
    }

    public async Task<string> GetAccessToken(User user, params Claim[] extra)
        => user switch
        {
            Customer customer => _jwt
                .GenerateJwtToken((await _elUserManager.GetElClaimsAsync(customer)).Union(extra)) 
          //  MobileUser mobileUser => _jwt.GenerateJwtToken((await _elUserManager.GetElClaimsAsync(mobileUser)).AddUserTypeClaim(ConstValues.UserType.MobileUser).Union(extra)),
        };
    public async Task<User?> GetUserById<TUser>(Guid id) where TUser : User
    {
        return await TrackingQuery<TUser>()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IdentityResult> RemoveAllRoles(User user)
    {
        var roles = await _elUserManager.GetRolesAsync(user);
        return await _elUserManager.RemoveFromRolesAsync(user, roles);
    }

    
}