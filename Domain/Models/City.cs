using Domain.Models.Base;
using Elkood.Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class City : Entity
    {
        public Guid Id { get; set; }
        public LanguageProperty? Name { get; set; }
        
        
    }
}
