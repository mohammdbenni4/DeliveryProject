using Application.Customers.Commands.AddCustomer;
using Application.Drivers.Commands.AddDriver;
using Application.Drivers.Commands.DeleteDriver;
using Application.Drivers.Queries;
using Application.Drivers.Queries.GetAll;
using Application.Drivers.Queries.GetById;
using DeliveryProjectApi.Util;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProjectApi.Controllers.Dash;

public class DriversController : ElApiController
{
    
    [HttpPost, ElRoute(ElApiGroupNames.Dashboard),ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(
        [FromServices] IRequestHandler<AddDriverCommand.Request, OperationResponse> handler
        , [FromForm] AddDriverCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
    
    
    [HttpGet, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(List<DriverDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        [FromServices] IRequestHandler<GetAllDriversQuery.Request,OperationResponse<List<DriverDto>>> handler,
        [FromQuery] GetAllDriversQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
    
    [HttpGet, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(List<DriverDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(
        [FromServices] IRequestHandler<GetDriverByIdQuery.Request,OperationResponse<DriverDto>> handler,
        [FromQuery] GetDriverByIdQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
    
    [HttpDelete, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(
        [FromServices] IRequestHandler<DeleteDriverCommand.Request, OperationResponse> handler,
        [FromBody] List<Guid> ids
        , [FromQuery] Guid? id)
        => await handler.HandleAsync(new (id,ids)).ToJsonResultAsync();
}