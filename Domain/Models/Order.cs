using Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Order :Entity
    {
        
        public Customer? Customer { get; set; }
        public Guid CustomerId{ get; set; }
        public string? MobileNumber { get; set; }
        public DateTime? Date{ get; set; }

        public Driver? Driver { get; set; }
        public Guid DriverId { get; set; }

        public bool PaymentImmedeitly { get; set; }

        public Address? Address { get; set; }
        public Guid AddressId { get; set; }

        public OrderStatus? OrderStatus { get; set; }
        public Guid OrderStatusId { get; set; }

    }
}
