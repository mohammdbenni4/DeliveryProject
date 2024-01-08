using Domain.Models.Base;
using Elkood.Domain.Primitives;

namespace Domain.Models
{
    public class Address : Entity
    {
       
        public Guid Id { get; set; }

        public LanguageProperty? Name { get; set; }

        public City? City { get; set; }
        public Guid CityId { get; set; }

        public Neighborhood? Neighborhood { get; set; }
        public Guid NeighborhoodId { get; set; }

        public LanguageProperty? Street { get; set; }
        public LanguageProperty? Building { get; set; }
        public LanguageProperty? Floor { get; set; }
        public LanguageProperty? MoreDetails { get; set; }

        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
    }
}
