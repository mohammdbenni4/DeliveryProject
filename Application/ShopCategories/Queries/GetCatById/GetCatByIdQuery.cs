using System.Linq.Expressions;
using Domain.Models;
using Domain.ShareMethods;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.ShopCategories.Queries.GetCatById;

public class GetCatByIdQuery
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        public Guid Id { get; set; }
    }
    public class Response
    {
       
        public Guid Id { get; set; }
        public string? Name { get; set; }
        
        public static Expression<Func<ShopCategory, Response>> Selector(string lang)
            => a => new()
            {
                Id = a.Id,
                Name = a.Name.GetByLanguage(lang),
               
            };
    }
}