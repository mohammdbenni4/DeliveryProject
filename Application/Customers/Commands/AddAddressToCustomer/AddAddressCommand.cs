using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.Customers.Commands.AddAddressToCustomer;

public class AddAddressCommand
{
    public class Request : IRequest<OperationResponse>
    {
        public Guid CustomerId { get; set; }
        public string? AddressName { get; set; }

        
        public Guid AddressCityId { get; set; }
        
        public Guid NeighborhoodId { get; set; }

        public string? Street { get; set; }
        public string? Building { get; set; }
        public string? Floor { get; set; }
        public string? MoreDetails { get; set; }
    }
   

}