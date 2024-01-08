using Application.Customers.Commands.AddAddressToCustomer;
using Application.Customers.Commands.AddCustomer;
using Application.Users.LogIn;
using DeliveryProjectApi.Util;
using Domain.Dtos.Users;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProjectApi.Controllers.Dash;


public class CustomersController : ElApiController
{
    [HttpPost, ElRoute(ElApiGroupNames.Dashboard),ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(
        [FromServices] IRequestHandler<AddCustomerCommand.Request, OperationResponse> handler
        , [FromBody] AddCustomerCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
    
    
   
    
    
   
}