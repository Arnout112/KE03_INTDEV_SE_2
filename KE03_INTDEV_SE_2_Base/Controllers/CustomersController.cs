using DataAccessLayer;
using DataAccessLayer.Models;
using KE03_INTDEV_SE_2_Base.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
    public class CustomersController : Controller
    {
        private readonly MatrixIncDbContext _context;

        public CustomersController(MatrixIncDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? searchString, string? isCustomerActive)
        {
            var customersQuery = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                customersQuery = customersQuery.Where(c =>
                    c.Name != null && c.Name.ToUpper().Contains(searchString.ToUpper())
                );
            }

            // Filter op actief/inactief als de waarde is opgegeven
            if (!string.IsNullOrEmpty(isCustomerActive))
            {
                if (bool.TryParse(isCustomerActive, out bool isActive))
                {
                    customersQuery = customersQuery.Where(c => c.Active == isActive);
                }
            }

            var customers = await customersQuery.ToListAsync();

            // Opties voor de dropdown: "Alle", "Actief", "Inactief"
            var activeOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Alle", Selected = string.IsNullOrEmpty(isCustomerActive) },
                new SelectListItem { Value = "true", Text = "Actief", Selected = isCustomerActive == "true" },
                new SelectListItem { Value = "false", Text = "Inactief", Selected = isCustomerActive == "false" }
            };

            var viewModel = new CustomerFilterViewModel
            {
                SearchString = searchString,
                IsCustomerActive = isCustomerActive,
                Customers = customers,
                ActiveOptions = activeOptions
            };

            return View(viewModel);
        }


        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StreetName,HouseNumber,PostalCode,CityName,Country,JoinDate,Active")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StreetName,HouseNumber,PostalCode,CityName,Country,JoinDate,Active")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        //Download file
        [HttpGet]
        public async Task<IActionResult> Download()
        {
            var customers = await _context.Customers.ToListAsync();

            var sb = new StringBuilder();
            sb.AppendLine("ID,Naam,Straat,Huisnummer,Postcode,Plaats,Land,Actief,Inschrijfdatum");

            foreach (var c in customers)
            {
                sb.AppendLine($"{c.Id}," +
                    $"\"{c.Name}\"," +
                    $"\"{c.StreetName}\"," +
                    $"\"{c.HouseNumber}\"," +
                    $"\"{c.PostalCode}\"," +
                    $"\"{c.CityName}\"," +
                    $"\"{c.Country}\"," +
                    $"{(c.Active ? "Ja" : "Nee")}," +
                    $"{c.JoinDate:dd-MM-yyyy}");
            }

            var bytes = Encoding.UTF8.GetBytes(sb.ToString());
            return File(bytes, "text/csv", "klanten.csv");
        }
    }
}
