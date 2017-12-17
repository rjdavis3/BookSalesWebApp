using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookSalesWebApp.Models;
using BookSalesWebApp.ViewModels;

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
            PopulateCustomersDropDownList();
            PopulateBooks();
            return View();
        }

        // POST: BookSales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CustomerID")] BookSale bookSale, string[] selectedBooks)
        {
            if (ModelState.IsValid)
            {
                List<BookSaleItem> bookSaleItems = new List<BookSaleItem>();
                foreach(var isbn in selectedBooks)
                {
                    Book bookToAdd = _context.Book.Find(isbn);
                    BookSaleItem bookSaleItemToAdd = new BookSaleItem();
                    bookSaleItemToAdd.TotalPrice = bookToAdd.ListPrice;
                    bookSaleItemToAdd.ISBN = bookToAdd.ISBN;
                    bookSaleItemToAdd.Quantity = 1;
                    bookSaleItems.Add(bookSaleItemToAdd);
                }
                bookSale.BookSaleItems = bookSaleItems;
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
                .Include(b => b.Customer).Include(b => b.BookSaleItems)
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

        private void PopulateCustomersDropDownList(object selectedCustomer = null)
        {
            var customersQuery = from d in _context.Customer
                                   orderby d.LastName
                                   select d;
            ViewBag.CustomerID = new SelectList(customersQuery, "ID", "FullName", selectedCustomer);
        }

        private void PopulateBooks()
        {
            var booksQuery = from d in _context.Book
                                orderby d.Title
                                select d;
            var viewModel = new List<SelectedBookData>();
            foreach (var book in booksQuery)
            {
                viewModel.Add(new SelectedBookData
                {
                    ISBN = book.ISBN,
                    Title = book.Title,
                    Selected = false
                });
            }
            ViewBag.Books = viewModel;
        }
    }
}
