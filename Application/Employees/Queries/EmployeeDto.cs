using Domain.Models;
using Elkood.Domain.Primitives;

namespace Application.Employees.Queries;

public class EmployeeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<string> MobileNumbers { get; set; } = new();
    //public DateOnly BirthDate { get; set; }
    public City City { get; set; }
  
    public string Address { get; set; }
    public string UserName { get; set; }

    public List<string> Documents { get; set; } = new();
    public string PhotoUrl { get; set; }
}