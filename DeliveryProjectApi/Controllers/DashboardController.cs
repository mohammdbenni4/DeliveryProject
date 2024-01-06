using Application.Cities.Commands.AddCity;
using Application.ShopCategories.Commands.AddShopCat;
using DeliveryProjectApi.Util;
using Domain.Models;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Identity.Policies.Permission;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
namespace DeliveryProjectApi.Controllers
{

    [ApiController]
    public class DashboardController : ElApiController
    {


        [HttpPost, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
        [ProducesResponseType(typeof(AddCityCommand.Response), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddCity(
            [FromServices] IRequestHandler<AddCityCommand.Request, OperationResponse<AddCityCommand.Response>>handler,
            [FromBody]AddCityCommand.Request city)
          =>  await handler.HandleAsync(city).ToJsonResultAsync();


        [HttpPost, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
        [ProducesResponseType(typeof(AddShopCatCommand.Response), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddShopCat(
            [FromServices] IRequestHandler<AddShopCatCommand.Request, OperationResponse<AddShopCatCommand.Response>> handler,
            [FromBody] AddShopCatCommand.Request request)
          => await handler.HandleAsync(request).ToJsonResultAsync();
    }
}