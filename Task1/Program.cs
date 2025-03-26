using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Task01.Context;
using Task01.Interfaces;
using Task01.Models;
using Task01.Repositories;

namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Configure Services
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TraineeDB>
            (
                op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnecton"))
            );

            builder.Services.AddScoped<ITrackRepository, TrackRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ITranieeRepository, TraineeRepository>();
            builder.Services.AddScoped<ITraineeCourseRepository, TraineeCourseRepository>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(op =>
            {
                op.Password.RequireUppercase = false;
                
                op.Password.RequiredLength = 4;
                op.Password.RequireNonAlphanumeric = false;
            })
                             .AddEntityFrameworkStores<TraineeDB>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
