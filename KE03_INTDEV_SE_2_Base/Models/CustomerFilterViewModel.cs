using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KE03_INTDEV_SE_2_Base.Models
{
    public class CustomerFilterViewModel
    {
        public string? SearchString { get; set; }
        public string? IsCustomerActive { get; set; }
        public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();
        public List<SelectListItem> ActiveOptions { get; set; } = new List<SelectListItem>();
    }
}