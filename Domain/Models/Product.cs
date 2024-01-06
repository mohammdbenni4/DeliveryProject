using Domain.Models.Base;
using Elkood.Domain.Primitives;

namespace Domain.Models
{
    public class Product : Entity
    {
      
        public LanguageProperty?  Name { get; set; }
        public int Price { get; set; }

        public Brunch? Brunch { get; set; }
        public Guid BrunchId { get; set; }

        public int Calories { get; set; }
        public LanguageProperty? Description { get; set; }
        public bool IsAvailable { get; set; }

        public List<string>? ProductImages { get; set; }

    }
}
