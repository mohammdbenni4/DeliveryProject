using Application.Cities.Commands.AddCity;
using Application.Cities.Queries.GetAllCities;
using DeliveryProjectApi.Util;
using Domain;
using Domain.Models;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Identity.Policies.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProjectApi.Controllers.Dash;

public class CitiesController : ElApiController
{
    [HttpPost, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(AddCityCommand.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(
        [FromServices] IRequestHandler<AddCityCommand.Request, OperationResponse<AddCityCommand.Response>>handler,
        [FromBody]AddCityCommand.Request city)
        =>  await handler.HandleAsync(city).ToJsonResultAsync();
    
    
    [AllowAnonymous]
    [HasPermissions(Permissions.Cities.Get,true)]
    [HttpGet, ElRoute(ElApiGroupNames.Dashboard), ElApiGroup(ElApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(List<City>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        [FromServices] IRequestHandler<GetAllCitiesQuery.Request, OperationResponse<GetAllCitiesQuery.Response>> handler,
        [FromQuery] GetAllCitiesQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
}