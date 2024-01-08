using Domain.Interfaces;
using Domain.Models.Security;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Identity.Mangers;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Delete;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand.Request,OperationResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly ElUserManager<User> _elUserManager;

    public DeleteUserHandler(ElUserManager<User> elUserManager, IUserRepository userRepository)
    {
        _elUserManager = elUserManager;
        _userRepository = userRepository;
    }

    public async Task<OperationResponse> HandleAsync(DeleteUserCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var users = await _userRepository
            .TrackingQuery<User>()
            .Where(u => request.Ids.Contains(u.Id))
            .ToListAsync(cancellationToken);

        await _elUserManager.SoftDeleteAsync(users);
        await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResponse.Success();

    }
}