using Domain.Interfaces;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Identity.Entities;
using Elkood.Identity.Mangers;
using Microsoft.EntityFrameworkCore;

namespace Application.Roles.Commands.AddPermissionsToRole;

public class AddPermissionsHandler : IRequestHandler<AddPermissionCommand.Request,OperationResponse>
{
    private readonly ElRoleManager<ElIdentityRole> _roleManager;
    private readonly IRepository _repository;

    public AddPermissionsHandler(ElRoleManager<ElIdentityRole> roleManager, IRepository repository)
    {
        _roleManager = roleManager;
        _repository = repository;
    }

    public async Task<OperationResponse> HandleAsync(AddPermissionCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var role = await _repository
            .TrackingQuery<ElIdentityRole>()
            .Where(er => request.RoleId.HasValue && er.Id == request.RoleId)
            .Include(er => er.RoleClaims)
            .FirstOrDefaultAsync(cancellationToken);
        
        role!.AddPermissions(request.Permissions);
        await _roleManager.UpdateAsync(role);
        return OperationResponse.Success();
    }
}