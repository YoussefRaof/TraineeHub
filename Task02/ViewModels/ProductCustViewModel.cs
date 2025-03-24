using System.ComponentModel.DataAnnotations;

namespace Task02.ViewModels
{
    public class ProductCustViewModel
    {
        [Required]
        public int Id { get; set; }
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = null!;

        public List<string> Products { get; set; } =new List<string>();    
    }
}
