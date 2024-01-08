using Application.Customers.Commands.AddAddressToCustomer;
using DeliveryProjectApi.Util;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProjectApi.Controllers.Dash;

public class AddressesController : ElApiController
{
    [HttpPost, ElRoute(ElApiGroupNames.Dashboard),ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(
        [FromServices]IRequestHandler<AddAddressCommand.Request,OperationResponse> handler
        , [FromBody] AddAddressCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
}