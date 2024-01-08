using Application.ShopCategories.Commands.AddShopCat;
using DeliveryProjectApi.Util;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProjectApi.Controllers.Dash;

public class ShopCategoriesController : ElApiController
{
    [HttpPost, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(AddShopCatCommand.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(
        [FromServices] IRequestHandler<AddShopCatCommand.Request, OperationResponse<AddShopCatCommand.Response>> handler,
        [FromBody] AddShopCatCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
}