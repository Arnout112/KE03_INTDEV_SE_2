using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KE03_INTDEV_SE_2_Base.Models
{
    public class ProductViewModel
    {
        public List<Product>? Products { get; set; }
        public SelectList? Parts { get; set; }
        public string? ProductPart { get; set; }
        public string? SearchString { get; set; }
        public bool isOnSale { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}
