using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.Drivers.Queries.GetById;

public class GetDriverByIdQuery
{
    public class Request : IRequest<OperationResponse<DriverDto>>
    {
        public Guid DriverId { get; set; }
    }
}