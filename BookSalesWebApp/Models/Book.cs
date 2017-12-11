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
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Valid ISBN-13 is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ISBN { get; set;}
        [Column(TypeName = "NVARCHAR(1000)")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Maximum length of {0} is 1000 characters.")]
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "NVARCHAR(1000)")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Maximum length of {0} is 1000 characters.")]
        [Required]
        public string Author { get; set; }
        [Display(Name = "List Price")]
        [DataType(DataType.Currency)]
        public decimal ListPrice { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

    }
}
