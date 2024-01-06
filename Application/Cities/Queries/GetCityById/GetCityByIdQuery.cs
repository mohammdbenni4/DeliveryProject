using System.Linq.Expressions;
using Domain.Models;
using Domain.ShareMethods;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.Cities.Queries.GetCityById;

public class GetCityByIdQuery
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        public Guid Id { get; set; }
    }
    public class Response
    {
        public Guid CityId { get; set; }
        public string? CityName { get; set; }
        
        public static Expression<Func<City, Response>> Selector(string lang)
            => a => new()
            {
                CityId = a.Id,
                CityName = a.Name.GetByLanguage(lang)
             
            };
    }
}