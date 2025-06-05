using DataAccessLayer;
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
            // Orders per maand
            var ordersPerMonth = await _context.Orders
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Count = g.Count()
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync();

            var ordersPerMonthFormatted = ordersPerMonth
                .Select(x => new
                {
                    Month = $"{x.Year}-{x.Month:00}",
                    Count = x.Count
                })
                .ToList();

            // Klanten geregistreerd per maand
            var customersPerMonth = await _context.Customers
                .GroupBy(c => new { c.JoinDate.Year, c.JoinDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Count = g.Count()
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync();

            var customersPerMonthFormatted = customersPerMonth
                .Select(x => new
                {
                    Month = $"{x.Year}-{x.Month:00}",
                    Count = x.Count
                })
                .ToList();

            // Totale omzet (totaal van alle order-producten)
            var allPrices = await _context.Orders
                .SelectMany(o => o.Products)
                .Select(p => p.Price)
                .ToListAsync();

            var totalRevenue = allPrices.Sum();

            // Producten met lage voorraad (bijvoorbeeld <= 3)
            var lowStockProducts = await _context.Products
                .Where(p => p.StockQuantity <= 3)
                .Select(p => new { p.Name, p.StockQuantity })
                .ToListAsync();

            ViewBag.OrdersPerMonth = ordersPerMonthFormatted;
            ViewBag.CustomersPerMonth = customersPerMonthFormatted;
            ViewBag.TotalRevenue = totalRevenue;
            ViewBag.LowStockProducts = lowStockProducts;

            return View();
        }
    }
}