using Domain.Models.Base;
using Elkood.Domain.Primitives;
using System.ComponentModel.DataAnnotations;
using Domain.Models.Security;

namespace Domain.Models
{
    public class Customer : User
    {
        public Guid Id { get; set; }
        public LanguageProperty? Name { get; set; }

        public City? City { get; set; }
        public Guid CityId { get; set; }

       // public string Email { get; set; }
        public string? MobileNumber { get; set; }
       
        
        public DateOnly? BornDate { get; set; }

        public List<Address> Address { get; set; }
        public List<Guid> AddressIds { get; set; }

    }
    
}
