using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.Shops.Queries.GetAllShops;

public class GetAllShopsQuery
{
    public class Request : IRequest<OperationResponse<List<Brunch>>>
    {
        public Guid? ShopCategoryId { get; set; }
        public Guid? CityId { get; set; }
    }
}