using Application.Roles.Queries.GetAll;
using Domain.Interfaces;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Identity.Entities;
using Elkood.Identity.Mangers;
using Microsoft.EntityFrameworkCore;

namespace Application.Roles.Commands.Upsert;

public class UpsertRoleHandler : IRequestHandler<UpsertRoleCommand.Request,
OperationResponse<GetAllRolesQuery.Response>>
{
    private readonly ElRoleManager<ElIdentityRole> _roleManager;
    private readonly IRepository _repository;

    public UpsertRoleHandler(ElRoleManager<ElIdentityRole> roleManager, IRepository repository)
    {
        _roleManager = roleManager;
        _repository = repository;
    }

    public async Task<OperationResponse<GetAllRolesQuery.Response>> HandleAsync(UpsertRoleCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var role = await _repository
            .TrackingQuery<ElIdentityRole>()
            .Where(er => request.Id.HasValue && er.Id == request.Id)
            .Include(er => er.RoleClaims)
            .FirstOrDefaultAsync(cancellationToken);
        
        if (role is null)
        {
            role = new ElIdentityRole(request.Name);
            role.AddPermissions(request.Permissions);
            var identityResult = await _roleManager.CreateAsync(role);
            if (!identityResult.Succeeded) return identityResult.ToOperationResponse<GetAllRolesQuery.Response>();
            
        }
        else
        {
            role.Name = request.Name;
            role.UpdatePermissions(request.Permissions);
            
            var identityResult = await _roleManager.UpdateAsync(role);
            if (!identityResult.Succeeded) return identityResult.ToOperationResponse<GetAllRolesQuery.Response>();

        }
        
        return await _repository.GetAsync(role.Id, GetAllRolesQuery.Response.Selector());
    }
}