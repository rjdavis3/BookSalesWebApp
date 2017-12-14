using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSalesWebApp.Models
{
    [Table("book_sale_items")]
    public class BookSaleItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("BookSaleItemFK")]
        public int ID { get; set; }

        [ForeignKey("BookFK")]
        [Column(TypeName = "VARCHAR(13)")]
        public string ISBN { get; set; }

        public long Quantity { get; set; }

        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

        public virtual Book Book {get; set;}

    }
}
