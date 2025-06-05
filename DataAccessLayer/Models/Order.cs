using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Order
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public int CustomerId { get; set; }

        [ValidateNever]
        public Customer Customer { get; set; } = null!;

        public DateTime? PaidAt { get; set; }

        public DateTime? ShippedAt { get; set; }

        public DateTime? DeliveredAt { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
