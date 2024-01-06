using Domain.Models.Base;
using Elkood.Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Shop :Entity
    {
        public LanguageProperty? Name { get; set; }
       
        public ShopCategory? ShopCategory { get; set; }
        public Guid ShopCategoryId { get; set; }

       

    }
}
