using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.Drivers.Queries.GetAll;

public class GetAllDriversQuery
{
    public class Request : IRequest<OperationResponse<List<DriverDto>>>
    {
       
    }
}