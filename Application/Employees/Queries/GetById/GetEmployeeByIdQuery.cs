using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.Employees.Queries.GetById;

public class GetEmployeeByIdQuery
{
    public class Request : IRequest<OperationResponse<EmployeeDto>>
    {
        public Guid EmployeeId { get; set; }
    }
}