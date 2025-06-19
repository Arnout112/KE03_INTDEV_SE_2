using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KE03_INTDEV_SE_2_Base.Models
{
    public class OrderFilterViewModel
    {
        public string? SearchString { get; set; }
        public string? OrderStatus { get; set; }
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();

        public List<SelectListItem> StatusOptions { get; set; } = new List<SelectListItem>();
    }
}