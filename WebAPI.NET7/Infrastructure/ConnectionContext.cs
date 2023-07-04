using Microsoft.EntityFrameworkCore;
using WebAPI.NET7.Domain.Model;
using WebAPI.NET7.Domain.Model.CompanyAggregate;

namespace WebAPI.NET7.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;" +
                "Database=Empresa;" +
                "User Id=postgres;" +
                "Password=123456;");
    }
}

