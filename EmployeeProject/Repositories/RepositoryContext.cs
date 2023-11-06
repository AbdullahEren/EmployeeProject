using EmployeeProject.Entities.Models;
using Microsoft.EntityFrameworkCore;
using EmployeeProject.Repositories.Config;

namespace EmployeeProject.Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
        }
    }
}
