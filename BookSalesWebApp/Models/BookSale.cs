using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSalesWebApp.Models
{
    [Table("book_sales")]
    public class BookSale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("BookSaleFK")]
        public int ID { get; set; }

        [ForeignKey("CustomerFK")]
        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<BookSaleItem> BookSaleItems { get; set; }

        [Display(Name = "Total Price")]
        public decimal TotalPrice
        {
            get
            {
                return 9.99M;
            }
        }
    }
}
