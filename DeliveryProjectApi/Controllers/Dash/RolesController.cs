using Application.Roles.Commands.Upsert;
using Application.Roles.Queries.GetAll;
using DeliveryProjectApi.Util;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProjectApi.Controllers.Dash;

public class RolesController : ElApiController
{
    [HttpPost,ElRoute(ElApiGroupNames.Dashboard),ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(GetAllRolesQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddRole([FromServices] IRequestHandler<UpsertRoleCommand.Request,
            OperationResponse<GetAllRolesQuery.Response>> handler,
        [FromBody] UpsertRoleCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
}