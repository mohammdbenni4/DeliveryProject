using Application.Brunches.Commands.AddBrunch;
using Application.Cities.Commands.AddCity;
using Application.Cities.Queries.GetAllCities;
using Application.ProductAddOnes.Commands.AddAddOne;
using Application.ProductCategories.Commands.AddProductCategoryToBrunch;
using Application.ProductCategories.Queries.GetProductCatForBrunch;
using Application.Products.Commands.AddProduct;
using Application.ShopCategories.Queries.GetAllCat;
using Application.Shops.Commands.AddShop;
using Application.Shops.Queries.GetAllShops;
using Application.Shops.Queries.GetShopById;
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
    
    public class ShopsController : ElApiController
    {
        [HasPermissions(Permissions.ShopCategories.Get,true)]
        [HttpGet, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
        [ProducesResponseType(typeof(GetAllCatQuery.Response), StatusCodes.Status200OK)]
        
        public async Task<IActionResult> GetAllShopCat(
           [FromServices] IRequestHandler<GetAllCatQuery.Request, OperationResponse<GetAllCatQuery.Response>> handler,
           [FromQuery] GetAllCatQuery.Request request)
         => await handler.HandleAsync(request).ToJsonResultAsync();
        
       
        
        
        // [HasPermissions(Permissions.Shops.Add,true)]
        [HttpPost, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
        [ProducesResponseType(typeof(AddShopCommand.Response), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(
            [FromServices] IRequestHandler<AddShopCommand.Request, OperationResponse<AddShopCommand.Response>> handler,
            [FromForm] AddShopCommand.Request request)
            => await handler.HandleAsync(request).ToJsonResultAsync();
        
        [HttpGet, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
        [ProducesResponseType(typeof(GetShopByIdQuery.Response), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(
            [FromServices] IRequestHandler<GetShopByIdQuery.Request, OperationResponse<GetShopByIdQuery.Response>> handler,
            [FromQuery] GetShopByIdQuery.Request request)
            => await handler.HandleAsync(request).ToJsonResultAsync();
        
         
        [HttpGet, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
        [ProducesResponseType(typeof(OperationResponse<List<Brunch>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromServices] IRequestHandler<GetAllShopsQuery.Request, OperationResponse<List<Brunch>>> handler,
            [FromQuery] GetAllShopsQuery.Request request)
            => await handler.HandleAsync(request).ToJsonResultAsync();
        
        
    }
}
