using System.Linq.Expressions;
using Domain.Models;
using Domain.ShareMethods;
using Elkood.Domain.Primitives;

namespace Application.ShopCategories.Queries.GetCatById;

public class GetCatByIdModel
{
    public class Request
    {
        public Guid Id { get; set; }
    }
    public class Response
    {
        public Guid Id { get; set; }
        public LanguageProperty? Name { get; set; }
        
        public static Expression<Func<ShopCategory, Response>> Selector()
            => a => new()
            {
                Id = a.Id,
                Name = a.Name
               
            };
        
    }
}