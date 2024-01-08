using Application.Neighborhoods.Commands.AddNeighborhood;
using DeliveryProjectApi.Util;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProjectApi.Controllers.Dash;

public class NeighborhoodsController : ElApiController
{
     
    [HttpPost, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(AddNeighborhoodCommand.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(
        [FromServices] IRequestHandler<AddNeighborhoodCommand.Request, OperationResponse<AddNeighborhoodCommand.Response>> handler,
        [FromBody] AddNeighborhoodCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
}