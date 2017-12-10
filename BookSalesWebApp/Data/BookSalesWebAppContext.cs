using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookSalesWebApp.Models
{
    public class BookSalesWebAppContext : DbContext
    {
        public BookSalesWebAppContext (DbContextOptions<BookSalesWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<BookSalesWebApp.Models.Book> Book { get; set; }
    }
}
