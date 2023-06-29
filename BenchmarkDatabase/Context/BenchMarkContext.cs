using BenchmarkDatabase.Entities;
using Microsoft.EntityFrameworkCore;

namespace BenchmarkDatabase.Context
{
    public class BenchMarkContext : DbContext
    {
        public BenchMarkContext(DbContextOptions<BenchMarkContext> options) 
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeNoAnnotation> EmployeesNoAnnotations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Initial Catalog=BrenchmarkTest;User=sa;Password=!234Password432!;TrustServerCertificate=True;");
        }
    }
}
