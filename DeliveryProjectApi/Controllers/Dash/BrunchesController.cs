using Application.Brunches.Commands.AddBrunch;
using DeliveryProjectApi.Util;
using Domain.Models;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProjectApi.Controllers.Dash;

public class BrunchesController : ElApiController
{
    [HttpPost, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(OperationResponse<Brunch>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(
        [FromServices]  IRequestHandler<AddBrunchCommand.Request
            ,OperationResponse<Brunch>> handler,
        [FromForm] AddBrunchCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
}