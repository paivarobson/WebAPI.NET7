using Microsoft.EntityFrameworkCore;
using WebAPI.NET7.Model;

namespace WebAPI.NET7.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;" +
                "Database=Empresa;" +
                "User Id=postgres;" +
                "Password=123456;");
    }
}

