using Domain.Models.Base;
using Elkood.Domain.Primitives;

namespace Domain.Models
{
    public class ProductAddOne :Entity
    {
      
        public LanguageProperty? Name { get; set; }

        public int Price { get; set; }
        public Product? Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
