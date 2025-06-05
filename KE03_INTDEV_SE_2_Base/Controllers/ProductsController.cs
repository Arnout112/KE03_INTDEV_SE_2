using DataAccessLayer;
using DataAccessLayer.Models;
using KE03_INTDEV_SE_2_Base.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MatrixIncDbContext _context;

        public ProductsController(MatrixIncDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(ProductViewModel filter)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'MatrixIncDbContext.Products' is null.");
            }

            IQueryable<string> partsQuery = from p in _context.Parts
                                            orderby p.Name
                                            select p.Name;

            var products = from m in _context.Products
                           select m;

            if (!string.IsNullOrEmpty(filter.SearchString))
            {
                products = products.Where(s =>
                    (s.Name != null && s.Name.ToUpper().Contains(filter.SearchString.ToUpper())) ||
                    (s.Description != null && s.Description.ToUpper().Contains(filter.SearchString.ToUpper()))
                );
            }

            if (!string.IsNullOrEmpty(filter.ProductPart))
            {
                products = products.Where(x => x.Parts.Any(p => p.Name == filter.ProductPart));
            }

            if (filter.IsOnSale)
            {
                products = products.Where(p => p.SalePrice.HasValue && p.SaleStartDate <= DateTime.UtcNow && p.SaleEndDate >= DateTime.UtcNow);
            }

            if (filter.MinPrice.HasValue)
            {
                products = products.Where(p => p.Price >= filter.MinPrice.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                products = products.Where(p => p.Price <= filter.MaxPrice.Value);
            }

            if (filter.StartDate.HasValue)
            {
                products = products.Where(p => p.CreatedAt >= filter.StartDate.Value);
            }

            if (filter.EndDate.HasValue)
            {
                products = products.Where(p => p.CreatedAt <= filter.EndDate.Value);
            }

            var productViewModel = new ProductViewModel
            {
                Products = await products.ToListAsync(),
                Parts = new SelectList(await partsQuery.Distinct().ToListAsync()),
                MinPrice = filter.MinPrice,
                MaxPrice = filter.MaxPrice,
                ProductPart = filter.ProductPart,
                SearchString = filter.SearchString,
                EndDate = filter.EndDate,
                StartDate = filter.StartDate,
                IsOnSale = filter.IsOnSale
            };

            return View(productViewModel);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ImageUrl,Price,SalePrice,SaleStartDate,SaleEndDate,StockQuantity,CreatedAt")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageUrl,Price,SalePrice,SaleStartDate,SaleEndDate,StockQuantity,CreatedAt")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
