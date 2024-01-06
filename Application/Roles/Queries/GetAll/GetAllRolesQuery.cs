using System.Linq.Expressions;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Identity.Entities;

namespace Application.Roles.Queries.GetAll;

public class GetAllRolesQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {
        
    }
    public class Response
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public static Expression<Func<ElIdentityRole, Response>> Selector() => r => new()
        {
            Id = r.Id,
            Name = r.Name!,
            
        };
    }
}