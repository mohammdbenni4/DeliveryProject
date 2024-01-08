using Domain.Models;
using Elkood.Domain.Primitives;

namespace Application.Drivers.Queries;

public class DriverDto
{
    public DriverDto()
    {
        
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<string> MobileNumbers { get; set; } = new();
    public DateOnly? BirthDate { get; set; }
    public string? Email { get; set; }
    public City City { get; set; }
    
    public string Address { get; set; }

    public List<string> WorkingDays { get; set; } = new();
        
        
    public string? TelegramId { get; set; }
    public bool ProfitIsPercentage{ get; set; }
    public int ProfitAmount { get; set; }
    public string BloodType { get; set; }

    public List<string> Documents { get; set; } =new();
    public string PhotoUrl { get; set; }
}