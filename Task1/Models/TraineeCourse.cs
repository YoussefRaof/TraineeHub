using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task01.Models
{
    public class TraineeCourse
    {
        [ForeignKey(nameof(Trainee))]
        public int TraineeId { get; set; }
        [ForeignKey(nameof(Course))]

        public int CourseId { get; set; }

        public Trainee? Trainee { get; set; } = null!;
        public Course? Course { get; set; } = null!;

        [Required]
        [Display(Name ="Trainee Grade After Taking Course")]
        [Column(TypeName ="decimal(18,2)")]
        public float Grade { get; set; }
    }
}
