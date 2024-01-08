using Domain.Models.Base;
using Elkood.Domain.Primitives;

namespace Domain.Models
{
    public class ProductAddOne :Entity
    {
        public ProductAddOne()
        {
            
        }
        public ProductAddOne(LanguageProperty name,int p, Guid productId)
        {
            Id= Guid.NewGuid();
            Name = name;
            Price = p;
            ProductId = productId;
        }
       
        public LanguageProperty? Name { get; set; }

        public int Price { get; set; }
        
        public Product? Product { get; private set; }
        public Guid ProductId { get; private set; }
    }
}
