using Application.Cities.Commands.AddCity;
using Application.Employees.Commands.Add;
using Application.Employees.Queries;
using Application.Employees.Queries.GetAll;
using Application.Employees.Queries.GetById;
using DeliveryProjectApi.Util;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProjectApi.Controllers.Dash;

public class EmployeesController : ElApiController
{
    [HttpPost, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(
        [FromServices] IRequestHandler<AddEmployeeCommand.Request, OperationResponse>handler,
        [FromForm]AddEmployeeCommand.Request request)
        =>  await handler.HandleAsync(request).ToJsonResultAsync();
    
    [HttpGet, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(List<EmployeeDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        [FromServices] IRequestHandler<GetAllEmployeesQuery.Request,OperationResponse<List<EmployeeDto>>> handler,
        [FromQuery] GetAllEmployeesQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
    
    [HttpGet, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(List<EmployeeDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(
        [FromServices] IRequestHandler<GetEmployeeByIdQuery.Request,OperationResponse<EmployeeDto>> handler,
        [FromQuery] GetEmployeeByIdQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();

}