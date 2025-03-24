using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Task01.Models;

namespace Task01.Context
{
    public class TraineeDB :DbContext
    {
        public TraineeDB(DbContextOptions<TraineeDB> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Track> Tracks{ get; set; }
        public DbSet<Trainee> Trainees{ get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<TraineeCourse> TraineesCourses { get; set; }
    }
}
