using System.Linq.Expressions;
using Domain.Dtos.Users;
using Domain.Models;
using Domain.ShareMethods;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.Users.LogIn;

public class LogInUserCommand
{
    public class Request : IRequest<OperationResponse<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class Response : TokenDashResDto
    {
        public List<string>? Permissions { get; set; }
       
        public string FullName { get; set; }
        
        
        public static Expression<Func<Customer, Response>> Selector(string accessToken,string lang) => e => new()
        {
            
            RefreshToken = e.PasswordHash!,
         
            FullName = e.Name.GetByLanguage(lang),
            //Permissions = e.UserRoles.SelectMany(ur => ur.Role.RoleClaims.Select(rc => rc.ClaimValue).ToList()).ToList()!,
            AccessToken = accessToken,
        };
    }
}