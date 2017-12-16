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

        public DbSet<BookSalesWebApp.Models.Customer> Customer { get; set; }

        public DbSet<BookSalesWebApp.Models.BookSale> BookSale { get; set; }

        public DbSet<BookSalesWebApp.Models.BookSaleItem> BookSaleItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookSale>()
                .HasMany(b => b.BookSaleItems)
                .WithOne(c => c.BookSale)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
