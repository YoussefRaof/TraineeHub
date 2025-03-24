using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using Task01.Validations;

namespace Task01.Models
{
    public enum Gender
    {
        Female=0,
        Male=1
    }
    public class Trainee :BaseEntity
    {

        [Required(ErrorMessage ="Enter Trainee Name")]
        [MaxLength(10)]
        [MinLength(5)]
        public string Name { get; set; } = null!;

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [UniqueEmail]
        public string Email { get; set; }=null!;

        [Required]
        [MaxLength(11)]
        [Display(Name="Mobile Number")]
      
        public string MobileNum { get; set; }=null!;

        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Birthday")]
        public DateTime Birthdate { get; set; }

        public Track? Trk { get; set; } = null!;
        [ForeignKey(nameof(Trk))]
        public int TrackId { get; set; }




    }
}
