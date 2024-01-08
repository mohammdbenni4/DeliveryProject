using Application.Products.Commands.AddProduct;
using DeliveryProjectApi.Util;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProjectApi.Controllers.Dash;

public class ProductsController :ElApiController
{
    [HttpPost, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(
        [FromServices]  IRequestHandler<AddProductCommand.Request,OperationResponse> handler,
        [FromForm]AddProductCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
}