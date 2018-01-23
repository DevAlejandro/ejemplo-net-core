using Microsoft.EntityFrameworkCore; // libreria para pode utilizar base de datos en memoria

namespace WebApplication1
{
    public class AppDbContext : DbContext
    
    {
        public AppDbContext(DbContextOptions option) : base(option)
        {

        }

        public DbSet<Customer> Customers { get; set; }

    }
}