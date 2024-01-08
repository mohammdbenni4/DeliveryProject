using Domain.Models.Base;
using Elkood.Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ProductCategory : Entity
    {
       
        public LanguageProperty? Name { get; set; }

        public Brunch? Brunch { get; set; }
        public Guid BrunchId { get; set; }

        public List<Product>? Product { get; set; } = new();
        public List<Guid>? ProductIds { get; set; } = new();

        public string? ImageUrl { get; set; } 
    }
}
