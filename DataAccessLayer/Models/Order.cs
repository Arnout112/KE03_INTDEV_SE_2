using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public int CustomerId { get; set; }
        
        public Customer Customer { get; set; } = null!;

        public DateTime? ShippedAt { get; set; }

        public DateTime? DeliveredAt { get; set; }

        public DateTime? PayedAt { get; set; }

        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
