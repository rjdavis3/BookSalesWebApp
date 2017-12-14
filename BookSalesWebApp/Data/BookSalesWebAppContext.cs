using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookSalesWebApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookSalesWebApp.Models
{
    public class BookSalesWebAppContext : DbContext
    {

        public BookSalesWebAppContext (DbContextOptions<BookSalesWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<BookSalesWebApp.Models.Book> Book { get; set; }

        public DbSet<BookSalesWebApp.Models.Customer> Customer { get; set; }

        public DbSet<BookSalesWebApp.Models.BookSale> BookSale { get; set; }

        public DbSet<BookSalesWebApp.Models.BookSaleItem> BookSaleItem { get; set; }

    }
}
