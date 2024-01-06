using Domain.Models.Base;
using Domain.ValueObjects;
using Elkood.Domain.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Brunch : Entity
    {
        
        public LanguageProperty? Name { get; set; }

        public bool IsMainBrunch { get; set; }
        public City? City { get; set; }
        public Guid CityId { get; set; }
        public string? MobileNumber { get; set; }
        public LanguageProperty? Address { get; set; }
        public Shop? Shop { get; set; }
        public Guid ShopId { get; set; }

        public bool  PaymentImmediatly { get; set; }
        public bool  DisplayThisBrunch { get; set; }

        public string? MainImage { get; set; }
        public List<string>? ImageUrls { get; set; }
        public LanguageProperty Description { get; set; }
        public bool  IsFeePercentage { get; set; }
        public float FeeValue { get; set; }
        public List<ProductCategory>? productCategories { get; set; }
        

        public List<Product>? Products { get; set; }
        
    }
}
