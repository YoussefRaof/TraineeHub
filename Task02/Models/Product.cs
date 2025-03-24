using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using Task02.CustomAttributes;

namespace Task02.Models
{
    public class Product :BaseEntity
    {
        [Required(ErrorMessage ="Product Name Is Required")]
        [MinLength(5,ErrorMessage ="Product Name Is At Least 5 Characters")]
        [MaxLength(50,ErrorMessage ="Product Name Is At Maximun 50 Characters")]
        public string Name { get; set; } = null!;

        [RegularExpression(@"^.*\.(?i:jpg|png)$", ErrorMessage = "Only images with extension (.jpg, .png) are allowed.")]

        [Required(ErrorMessage ="Image Is Required")]
        public string Image { get; set; } = null!;

        [Required(ErrorMessage = "Price Is Required")]
        [ValidatePrice] //Price > 200
        public double Price { get; set; }

        [Required(ErrorMessage = "Product Description Is Required")]
        [MaxLength(50, ErrorMessage = "Product Description Is At Maximun 50 Characters")]
        public string Description { get; set; } = null!;

        [ForeignKey(nameof(Customer))]
        public int CustId { get; set; }
        public Customer? Customer { get; set; } = null!;

    }
}
