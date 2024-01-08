using Application.ProductCategories.Commands.AddProductCategoryToBrunch;
using Application.ProductCategories.Queries.GetProductCatForBrunch;
using DeliveryProjectApi.Util;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProjectApi.Controllers.Dash;

public class ProductCategoriesController :ElApiController
{
    
    [HttpPost, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(
        [FromServices]  IRequestHandler<AddProductCatCommand.Request,OperationResponse> handler,
        [FromForm] AddProductCatCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
    
    [HttpGet, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(OperationResponse<List<GetProductCatForBrunchQuery.Response>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByBrunchId(
        [FromServices] IRequestHandler<GetProductCatForBrunchQuery.Request,
            OperationResponse<List<GetProductCatForBrunchQuery.Response>>> handler,
        [FromQuery] GetProductCatForBrunchQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();

}