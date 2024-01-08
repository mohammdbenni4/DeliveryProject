using Application.Users.Delete;
using Application.Users.LogIn;
using DeliveryProjectApi.Util;
using Domain.Dtos.Users;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProjectApi.Controllers.Dash;

public class UsersController : ElApiController
{
    [HttpPost, ElRoute(ElApiGroupNames.Dashboard),ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(TokenDashResDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> LogIn(
        [FromServices] IRequestHandler<LogInUserCommand.Request,OperationResponse<string>>
            handler
        , [FromBody] LogInUserCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
    
    [HttpDelete, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteUsers(
        [FromServices] IRequestHandler<DeleteUserCommand.Request, OperationResponse> handler,
        [FromBody] List<Guid> ids
        , [FromQuery] Guid? id)
        => await handler.HandleAsync(new (id,ids)).ToJsonResultAsync();
    
}