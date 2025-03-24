using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task01.Models;

namespace Task01.Config
{
    public class TraineeCourseConfigurations : IEntityTypeConfiguration<TraineeCourse>
    {
        public void Configure(EntityTypeBuilder<TraineeCourse> builder)
        {
            builder.HasKey(Tc => new {Tc.TraineeId, Tc.CourseId});
            
        }
    }
}
