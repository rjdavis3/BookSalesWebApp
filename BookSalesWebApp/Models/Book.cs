using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSalesWebApp.Models
{
    [Table("books")]
    public class Book
    {
        [Key]
        [Column(TypeName = "VARCHAR(13)")]
        [StringLength(13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String ISBN { get; set;}
        public string Title { get; set; }
        public string Author { get; set; }
        [Display(Name = "List Price")]
        [DataType(DataType.Currency)]
        public decimal ListPrice { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

    }
}
