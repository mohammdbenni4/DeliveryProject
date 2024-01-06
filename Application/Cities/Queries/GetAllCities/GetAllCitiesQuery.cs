using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using System.Linq.Expressions;
using Domain.ShareMethods;
namespace Application.Cities.Queries.GetAllCities
{
    public class GetAllCitiesQuery
    {
        public class Request : IRequest<OperationResponse<Response>>
        {
           // public static string lang {  get; set; }
           
        }

        public class Response
        {
            public List<CityDto> Cities { get; set; }
           
            public class CityDto
            {
                public Guid Id { get; set; }
                public string? Name { get; set; }
                
            }
           
            public static Expression<Func<City, CityDto>> Selector(string lang  )
             => a => new()
             {
                 Id = a.Id,
                 Name =a.Name.GetByLanguage(lang),
             };
        }

        

    }
}
