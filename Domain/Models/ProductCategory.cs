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

        public Product? Product { get; set; }
        public Guid ProductId { get; set; }

        public List<string>? ImageUrl { get; set; }
    }
}
