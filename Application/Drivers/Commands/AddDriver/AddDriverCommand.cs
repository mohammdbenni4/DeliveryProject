using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Http;

namespace Application.Drivers.Commands.AddDriver;

public class AddDriverCommand
{
    public class Request : IRequest<OperationResponse>
    {
        public string? Name { get; set; }
        public List<string> MobileNumbers { get; set; } = new();
        public DateOnly? BirthDate { get; set; }
        public string? Email { get; set; }
      
        public Guid CityId { get; set; }
        public string? Address { get; set; }

        public List<string> WorkingDays { get; set; } = new();
    
        
        public string? TelegramId { get; set; }
        public bool ProfitIsPercentage{ get; set; }
        public int ProfitAmount { get; set; }
        public string? BloodType { get; set; }

        public List<IFormFile> Documents { get; set; } = new();
        public IFormFile? PhotoFile { get; set; }
    }
}