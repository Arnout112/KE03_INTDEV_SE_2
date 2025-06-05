using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
    public class OrdersController : Controller
    {
        private readonly MatrixIncDbContext _context;

        public OrdersController(MatrixIncDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Products)
                .ToListAsync();
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Products)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            ViewData["Products"] = new MultiSelectList(_context.Products, "Id", "Name");
            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(OrderStatus)));
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderDate,CustomerId,Status")] Order order, int[] selectedProductIds)
        {
            Debug.WriteLine($"ModelState valid: {ModelState.IsValid}");

            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Debug.WriteLine($"❌ {entry.Key}: {error.ErrorMessage}");
                    }
                }
            }

            if (ModelState.IsValid)
            {
                order.Products = await _context.Products
                    .Where(p => selectedProductIds.Contains(p.Id))
                    .ToListAsync();

                _context.Add(order);
                await _context.SaveChangesAsync();
                Debug.WriteLine("✅ Order opgeslagen!");
                return RedirectToAction(nameof(Index));
            }

            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", order.CustomerId);
            ViewData["Products"] = new MultiSelectList(_context.Products, "Id", "Name", selectedProductIds);
            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(OrderStatus)), order.Status);
            return View(order);
        }


        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders
                .Include(o => o.Products)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();

            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", order.CustomerId);
            ViewData["Products"] = new MultiSelectList(_context.Products, "Id", "Name", order.Products.Select(p => p.Id));
            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(OrderStatus)), order.Status);
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderDate,CustomerId,Status")] Order order, int[] selectedProductIds)
        {
            if (id != order.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var existingOrder = await _context.Orders
                    .Include(o => o.Products)
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (existingOrder == null) return NotFound();

                existingOrder.OrderDate = order.OrderDate;
                existingOrder.CustomerId = order.CustomerId;
                existingOrder.Status = order.Status;

                existingOrder.Products.Clear();
                var newProducts = await _context.Products
                    .Where(p => selectedProductIds.Contains(p.Id))
                    .ToListAsync();

                foreach (var product in newProducts)
                {
                    existingOrder.Products.Add(product);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", order.CustomerId);
            ViewData["Products"] = new MultiSelectList(_context.Products, "Id", "Name", selectedProductIds);
            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(OrderStatus)), order.Status);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Products)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order != null)
            {
                order.Products.Clear();
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
