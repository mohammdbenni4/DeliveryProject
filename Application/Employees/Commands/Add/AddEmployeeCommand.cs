using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Http;

namespace Application.Employees.Commands.Add;

public class AddEmployeeCommand
{
    public class Request : IRequest<OperationResponse>
    {
        public string Name { get; set; }
        public List<string> MobileNumbers { get; set; } = new();
        public DateOnly BirthDate { get; set; }
     
        public Guid CityId { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<IFormFile> Documents { get; set; } = new();
        public IFormFile PhotoUrl { get; set; }
    }
}