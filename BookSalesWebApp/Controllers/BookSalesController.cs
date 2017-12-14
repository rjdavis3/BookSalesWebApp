using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookSalesWebApp.Models;

namespace BookSalesWebApp.Controllers
{
    public class BookSalesController : Controller
    {
        private readonly BookSalesWebAppContext _context;

        public BookSalesController(BookSalesWebAppContext context)
        {
            _context = context;
        }

        // GET: BookSales
        public async Task<IActionResult> Index()
        {
            var bookSalesWebAppContext = _context.BookSale.Include(b => b.Customer).Include(b => b.BookSaleItems);
            return View(await bookSalesWebAppContext.ToListAsync());
        }

        // GET: BookSales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookSale = await _context.BookSale
                .Include(b => b.Customer).Include(b => b.BookSaleItems)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bookSale == null)
            {
                return NotFound();
            }

            return View(bookSale);
        }

        // GET: BookSales/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "CustomerID");
            return View();
        }

        // POST: BookSales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CustomerID")] BookSale bookSale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "CustomerID", bookSale.CustomerID);
            return View(bookSale);
        }

        // GET: BookSales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookSale = await _context.BookSale
                .Include(b => b.Customer)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bookSale == null)
            {
                return NotFound();
            }

            return View(bookSale);
        }

        // POST: BookSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookSale = await _context.BookSale.SingleOrDefaultAsync(m => m.ID == id);
            _context.BookSale.Remove(bookSale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookSaleExists(int id)
        {
            return _context.BookSale.Any(e => e.ID == id);
        }
    }
}
