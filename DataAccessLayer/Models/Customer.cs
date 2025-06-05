using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? StreetName { get; set; }

        [Required]
        public string? Country { get; set; }

        [Required]
        public string? PostalCode { get; set; }

        [Required]
        public string? HouseNumber { get; set; }

        [Required]
        public string? CityName { get; set; }

        [Required]
        public DateTime JoinDate { get; set; } = DateTime.Today;

        public bool Active { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}