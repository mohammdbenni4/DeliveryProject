using Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class OrdersBrunchesProduct : Entity
    {
       
        public OrdersBrunches? OrdersBrunches { get; set; }
        public Guid OrdersBrunchesId { get; set; }
        public Product? Product { get; set; }
        public Guid ProductId { get; set; }
        public int Price { get; set; }
    }
}
