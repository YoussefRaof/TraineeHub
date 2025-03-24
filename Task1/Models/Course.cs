using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task01.Models
{
    public class Course : BaseEntity
    {
        [Required(ErrorMessage = "Enter Topic Name")]
        [Display(Name = "Topic Name")]
        [MaxLength(20)]
        [MinLength(2)]
        public string Topic { get; set; } = null!;

        [Required(ErrorMessage = "Enter Course Total Grade")]
        [Column(TypeName = "decimal(18,2)")]
        public float Grade { get; set; }
    }
}
