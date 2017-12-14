using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
                if(BookSaleItems == null)
                {
                    return 0;
                }
                return BookSaleItems.Sum(BookSaleItem => BookSaleItem.TotalPrice);
            }
        }
    }
}
