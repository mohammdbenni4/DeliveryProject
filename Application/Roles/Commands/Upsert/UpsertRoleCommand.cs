using Application.Roles.Queries.GetAll;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.Roles.Commands.Upsert;

public class UpsertRoleCommand
{
    public class Request : IRequest<OperationResponse<GetAllRolesQuery.Response>>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public List<string> Permissions { get; set; }
    }
}