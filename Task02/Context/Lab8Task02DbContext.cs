using Microsoft.EntityFrameworkCore;
using Task02.Models;
using Task02.ViewModels;

namespace Task02.Context
{
    public class Lab8Task02DbContext : DbContext
    {
        public Lab8Task02DbContext(DbContextOptions<Lab8Task02DbContext> options) : base(options) 
        {
            
        }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Task02.ViewModels.ProductCustViewModel> ProductCustViewModel { get; set; } = default!;
    }
}
