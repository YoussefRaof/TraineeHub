using System.ComponentModel.DataAnnotations;

namespace Task01.Models
{
    public class Track :BaseEntity
    {
        [Required(ErrorMessage ="Track Name Is Required")]
        [MinLength(2,ErrorMessage = "Minimun 2 Letters")]
        [Display(Name="Track Name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage ="Enter Track Description")]
        [MaxLength(50,ErrorMessage ="Maxmimum 50 Letter")]
        [Display(Name="Track Description")]
        public string Description { get; set; } = null!;

        public IEnumerable<Trainee>? Trainees{ get; set; } 
    }
}
