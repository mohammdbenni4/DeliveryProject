using Application.ProductAddOnes.Commands.AddAddOne;
using DeliveryProjectApi.Util;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProjectApi.Controllers.Dash;

public class ProductAddOnesController : ElApiController
{
    [HttpPost, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(
        [FromServices]  IRequestHandler<AddAddOneCommand.Request,OperationResponse> handler,
        [FromForm] AddAddOneCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();

}