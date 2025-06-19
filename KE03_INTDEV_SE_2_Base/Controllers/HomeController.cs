using DataAccessLayer;
using DataAccessLayer.Models;
using KE03_INTDEV_SE_2_Base.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
    public class HomeController : Controller
    {
        private readonly MatrixIncDbContext _context;

        public HomeController(MatrixIncDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.Products)
                .ToListAsync();
            var customers = await _context.Customers.ToListAsync();

            var ordersPerMonth = orders
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new MonthCount
                {
                    Month = $"{g.Key.Year}-{g.Key.Month:00}",
                    Count = g.Count()
                })
                .OrderBy(x => x.Month)
                .ToList();

            var customersPerMonth = customers
                .GroupBy(c => new { c.JoinDate.Year, c.JoinDate.Month })
                .Select(g => new MonthCount
                {
                    Month = $"{g.Key.Year}-{g.Key.Month:00}",
                    Count = g.Count()
                })
                .OrderBy(x => x.Month)
                .ToList();

            var totalRevenue = orders
                .SelectMany(o => o.Products)
                .Sum(p => p.Price);

            var lowStockProducts = await _context.Products
                .Where(p => p.StockQuantity < 5)
                .OrderBy(p => p.StockQuantity)
                .ToListAsync();

            var model = new DashboardViewModel
            {
                OrdersPerMonth = ordersPerMonth,
                CustomersPerMonth = customersPerMonth,
                TotalRevenue = totalRevenue,
                LowStockProducts = lowStockProducts
            };

            return View(model);
        }
    }
}
