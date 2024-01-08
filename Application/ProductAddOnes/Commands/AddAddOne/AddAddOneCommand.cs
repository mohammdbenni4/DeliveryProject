using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Primitives;

namespace Application.ProductAddOnes.Commands.AddAddOne;

public class AddAddOneCommand
{
    public class Request : IRequest<OperationResponse>
    {
      
        public string? Name { get; set; }
        public int price { get; set; }
        public Guid ProductId { get; set; }
    }
}