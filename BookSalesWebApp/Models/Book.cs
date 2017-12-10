using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookSalesWebApp.Models
{
    [Table("books")]
    public class Book
    {
        [Key]
        public int isbn { get; set;}
        public string title { get; set; }
        public string author { get; set; }
        public decimal listPrice { get; set; }
        public string releaseDate { get; set; }

    }
}
