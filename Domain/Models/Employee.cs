using Domain.Models.Security;
using Elkood.Domain.Primitives;

namespace Domain.Models;

public class Employee : User
{
    public LanguageProperty Name { get; set; }

    public List<string> MobileNumbers { get; set; } = new();
    //public DateOnly BirthDate { get; set; }
    public City City { get; set; }
    public Guid CityId { get; set; }
    public LanguageProperty Address { get; set; }
    public string UserName { get; set; }

    public List<string> Documents { get; set; } = new();
    public string PhotoUrl { get; set; }
    
}