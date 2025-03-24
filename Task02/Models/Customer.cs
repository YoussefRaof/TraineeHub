using System.ComponentModel.DataAnnotations;
using Task02.CustomAttributes;

namespace Task02.Models
{
    public enum Gender
    {
        Female=0,
        Male =1
    }
    public class Customer :BaseEntity
    {   
        [Required(ErrorMessage = "Customer Name Is Required")]
        [MinLength(4,ErrorMessage ="Min Length Of Customer Name Is 4 Letters")]
        [MaxLength(20 ,ErrorMessage ="Max Length Of Customer Name Is 20 Charachters")]
        public string Name { get; set; } = null!;

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Customer Email Is Required")]
        [DataType(DataType.EmailAddress)]
        [UniqueEmailAtttribute]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Phone Number Is Required ")]
        [MinLength(6, ErrorMessage = "Phone Must  Exceed 6 Numbers")]
        [MaxLength(11, ErrorMessage = "Phone Must Not Exceed 11 Numbers")]
    
        public string PhoneNum { get; set; } = null!;

        public IEnumerable<Product>? Produdcts { get; set; }
    }
}
