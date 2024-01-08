using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.Employees.Queries.GetAll;

public class GetAllEmployeesQuery
{
    public class Request : IRequest<OperationResponse<List<EmployeeDto>>>
    {
    }
}