using Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class OrdersBrunches : Entity
    {
       
        public Brunch? Brunch { get; set; }
        public Guid BrunchId { get; set; }
        public Order? Order { get; set; }
        public Guid OrderId { get; set; }



    }
}
