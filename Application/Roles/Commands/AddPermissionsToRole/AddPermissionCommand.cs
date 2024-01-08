using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.Roles.Commands.AddPermissionsToRole;

public class AddPermissionCommand
{
    public class Request : IRequest<OperationResponse>
    {
        public Guid? RoleId { get; set; }
        public List<string> Permissions { get; set; }
    }
}