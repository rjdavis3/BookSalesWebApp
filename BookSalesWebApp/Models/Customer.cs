using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSalesWebApp.Models
{
    [Table("customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set;}
        [Column(TypeName = "NVARCHAR(300)")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Maximum length of {0} is 300 characters.")]
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Column(TypeName = "NVARCHAR(300)")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Maximum length of {0} is 300 characters.")]
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Column(TypeName = "NVARCHAR(300)")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Maximum length of {0} is 300 characters.")]
        [Display(Name = "Address 1")]
        [Required]
        public string Address1 { get; set; }
        [Column(TypeName = "NVARCHAR(300)")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Maximum length of {0} is 300 characters.")]
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }
        [Column(TypeName = "NVARCHAR(300)")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Maximum length of {0} is 300 characters.")]
        [Required]
        public string City { get; set; }
        [Column(TypeName = "NVARCHAR(300)")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Maximum length of {0} is 300 characters.")]
        [Required]
        public string Province { get; set; }
        [Column(TypeName = "NVARCHAR(300)")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Maximum length of {0} is 300 characters.")]
        [Required]
        public string Country { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Maximum length of {0} is 50 characters.")]
        [Display(Name = "Postal Code")]
        [Required]
        public string PostalCode { get; set; }
    }
}
