using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.Shops.Queries.GetShopById;

public class GetShopByIdQuery
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        public Guid? ShopId { get; set; }
    }
    public class Response
    {
        public Brunch BrunchSelected { get; set; }
        public List<Brunch> Brunches { get; set; } = new();
        public List<ProductCategory> CategoriesInSelectedBrunch { get; set; } = new();
        public List<Product> ProductsInSelectedBrunch { get; set; } = new();
    }
}