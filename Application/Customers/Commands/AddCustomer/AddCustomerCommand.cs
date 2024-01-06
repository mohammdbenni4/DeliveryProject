using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.Customers.Commands.AddCustomer;

public class AddCustomerCommand
{
    public class Request : IRequest<OperationResponse>
    {
        
        //Add Customer
        public string? Name { get; set; }
        
        public Guid CityId { get; set; }

        public string Email { get; set; }
        public string? MobileNumber { get; set; }
        public string RoleName { get; set; }
        public string Password { get; set; }
        
        public DateOnly? BornDate { get; set; }
        
        
        //Add Address for this Customer
        
        
        
        
        
        
    }
}