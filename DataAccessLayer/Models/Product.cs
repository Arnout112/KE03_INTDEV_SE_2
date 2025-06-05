using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Product
    {        
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [DataType(DataType.Currency)]
        public decimal? SalePrice { get; set; }

        public DateTime? SaleStartDate { get; set; }
        public DateTime? SaleEndDate { get; set; }

        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<Part> Parts { get; set; } = new List<Part>();
    }
}
