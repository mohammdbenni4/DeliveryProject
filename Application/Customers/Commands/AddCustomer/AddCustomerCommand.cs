using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Primitives;

namespace Application.Customers.Commands.AddCustomer;

public class AddCustomerCommand
{
    public class Request : IRequest<OperationResponse>
    {
        
        //Add Customer
        public string? CustomerName { get; set; }
        
        public Guid CityIdCustomer { get; set; }

        public string Email { get; set; }
        public string? MobileNumber { get; set; }
     //   public string RoleName { get; set; }
        public string Password { get; set; }
        
        public DateOnly? BornDate { get; set; }
        
        
        //Add Address for this Customer
        
        public string? AddressName { get; set; }

        
        public Guid AddressCityId { get; set; }
        
        public Guid NeighborhoodId { get; set; }

        public string? Street { get; set; }
        public string? Building { get; set; }
        public string? Floor { get; set; }
        public string? MoreDetails { get; set; }
        
        
        
        
    }
}