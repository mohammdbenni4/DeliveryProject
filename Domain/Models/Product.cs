using Domain.Models.Base;
using Elkood.Domain.Primitives;

namespace Domain.Models
{
    public class Product : Entity
    {
        public Product()
        {
        }

        public LanguageProperty? Name { get; set; }
        public int Calories { get; set; }
        public int Price { get; set; }
        public LanguageProperty? Description { get; set; }
        

        private readonly List<ProductAddOne> _addOnes = new();
        public IReadOnlyCollection<ProductAddOne> AddOnes => _addOnes.AsReadOnly();

        public ProductCategory ProductCategory { get; set; }
        public Guid productCategoryId { get; set; }

        public bool IsAvailable { get; set; }
        public string? MainImage { get; set; }

        public List<string>? ProductImages { get; set; } = new();

        
        public Brunch? Brunch { get; set; }
        public Guid BrunchId { get; set; }


        public void AddProductExtra(ProductAddOne productAddOne)
        {
            _addOnes.Add(productAddOne);
        }
    }
}