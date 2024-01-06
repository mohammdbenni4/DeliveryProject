using Elkood.Domain.Exceptions;
using Elkood.Domain.Exceptions.Http;

namespace Domain.Error;

public class DomainError
{
      public static class User
    {
        public static HttpMessage EmailAlreadyExist(string? email = null) => new($"{email ?? "the email"} is already exist",
            HttpStatusCode.BadRequest400);
        public static HttpMessage PhoneNumberAlreadyUsed => new("This Phone Number is Already Used",
            HttpStatusCode.BadRequest400);
        public static HttpMessage PhoneNumberIsRequired => new("At least one number is required ",
            HttpStatusCode.BadRequest400);
        public static HttpMessage PhoneNumberMustStart09 => new("PhoneNumber must start with 09",
            HttpStatusCode.BadRequest400);
        public static HttpMessage MustCreateAccount => new("Must create account first",
            HttpStatusCode.Accepted202);
        public static HttpMessage NotFound => new("User Not Found",
            HttpStatusCode.NotFound404);
        public static HttpMessage Blocked => new("User is Blocked",
            HttpStatusCode.NotFound404);
        public static HttpMessage EmailOrPasswordWrong => new("Email or Password Wrong",
            HttpStatusCode.BadRequest400); 
        
        public static HttpMessage PhoneNumberOrPasswordWrong => new("PhoneNumber or Password Wrong",
            HttpStatusCode.BadRequest400);
        public static HttpMessage NumberIsRequired => new("At least one number is required ",
            HttpStatusCode.BadRequest400);
        public static HttpMessage NotAllowedToAccess() =>
            new("you're not allowed to access this user", HttpStatusCode.Unauthorized401);
        public static HttpMessage EmailNotExist() => new("Email is not exist", HttpStatusCode.BadRequest400);
        public static HttpMessage InvalidRefreshToken => new("Invalid Refresh Token", HttpStatusCode.BadRequest400);
        public static HttpMessage ExpiredCode() => new("Expired code, new code is sent", HttpStatusCode.BadRequest400);
        public static HttpMessage WrongCode() => new($"Wrong code", HttpStatusCode.BadRequest400);

        public static HttpMessage AlreadyHaveArea() => new("already added this area", HttpStatusCode.BadRequest400);

        public static HttpMessage AreasShouldBeInOneCity() => new("Areas should be in one city", HttpStatusCode.BadRequest400);
    }
}