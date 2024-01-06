using Application.Cities.Commands.AddCity;
using Application.Cities.Queries.GetAllCities;
using Application.ShopCategories.Queries.GetAllCat;
using Application.Shops.Commands.AddShop;
using DeliveryProjectApi.Util;
using Domain;
using Domain.Models;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Identity.Policies.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProjectApi.Controllers.Dash
{
    
    [ApiController]
    public class ShopsController : ElApiController
    {
        [HasPermissions(Permissions.ShopCategories.Get,true)]
        [HttpGet, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
        [ProducesResponseType(typeof(GetAllCatQuery.Response), StatusCodes.Status200OK)]
        
        public async Task<IActionResult> GetAllShopCat(
           [FromServices] IRequestHandler<GetAllCatQuery.Request, OperationResponse<GetAllCatQuery.Response>> handler,
           [FromQuery] GetAllCatQuery.Request request)
         => await handler.HandleAsync(request).ToJsonResultAsync();
        
        [AllowAnonymous]
        [HasPermissions(Permissions.Cities.Get,true)]
        [HttpGet, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
        [ProducesResponseType(typeof(List<City>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCities(
           [FromServices] IRequestHandler<GetAllCitiesQuery.Request, OperationResponse<GetAllCitiesQuery.Response>> handler,
           [FromQuery] GetAllCitiesQuery.Request request)
         => await handler.HandleAsync(request).ToJsonResultAsync();
        
        
        [HasPermissions(Permissions.Shops.Add,true)]
        [HttpPost, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
        [ProducesResponseType(typeof(AddShopCommand.Response), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddNewShop(
            [FromServices] IRequestHandler<AddShopCommand.Request, OperationResponse<AddShopCommand.Response>> handler,
            [FromForm] AddShopCommand.Request request)
            => await handler.HandleAsync(request).ToJsonResultAsync();
        
    }
}
