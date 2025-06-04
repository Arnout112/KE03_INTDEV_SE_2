using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            ViewBag.AllProducts = _context.Products.ToList(); // lijst voor checkboxes
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order, [FromForm] List<int> selectedProducts)
        {
            if (ModelState.IsValid)
            {
                var products = await _context.Products.Where(p => selectedProducts.Contains(p.Id)).ToListAsync();
                foreach (var product in products)
                {
                    order.Products.Add(product);
                }

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", order.CustomerId);
            ViewBag.AllProducts = _context.Products.ToList();
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
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order, int[] selectedProducts)
        {
            if (id != order.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);

                    var existingOrder = await _context.Orders
                        .Include(o => o.Products)
                        .FirstOrDefaultAsync(o => o.Id == id);

                    if (existingOrder != null)
                    {
                        existingOrder.Products.Clear();
                        var selected = await _context.Products.Where(p => selectedProducts.Contains(p.Id)).ToListAsync();
                        foreach (var product in selected)
                        {
                            existingOrder.Products.Add(product);
                        }

                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Orders.Any(e => e.Id == order.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", order.CustomerId);
            ViewData["Products"] = new MultiSelectList(_context.Products, "Id", "Name", selectedProducts);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
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
