using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;


namespace Application.ProductCategories.Queries.GetProductCatForBrunch;

public class GetProductCatForBrunchQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {
        public Guid BrunchId { get; set; }
    }
    public class Response
    {
        public Guid CatId { get; set; }
        public string Name { get; set; }
    }
    
}