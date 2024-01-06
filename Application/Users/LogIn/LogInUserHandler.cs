using Domain.Error;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Security;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.Core.Abstractions.Resolver;
using Elkood.Application.OperationResponses;
using Elkood.Identity.Mangers;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.LogIn;

public class LogInUserHandler : IRequestHandler<LogInUserCommand.Request,OperationResponse<string>>
{
    private readonly IUserRepository _userRepository;
    private readonly IHttpResolverService _httpResolverService;
    private readonly ElUserManager<User> _userManager;

    public LogInUserHandler(ElUserManager<User> userManager, IUserRepository userRepository, IHttpResolverService httpResolverService)
    {
        _userManager = userManager;
        _userRepository = userRepository;
        _httpResolverService = httpResolverService;
    }

    public async Task<OperationResponse<string>> HandleAsync(LogInUserCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var user = await _userRepository.Query<Customer>()
            .FirstOrDefaultAsync(d => d.NormalizedEmail == request.Email.ToUpper(), cancellationToken);

        if (user == null)
            return DomainError.User.NotFound;

        if (!await _userManager.CheckPasswordAsync(user, request.Password))
            return DomainError.User.EmailOrPasswordWrong;

        if (user.DateBlocked.HasValue)
            return DomainError.User.Blocked;

        var accessToken = await _userRepository.GetAccessToken(user);
        return accessToken;

    }
}