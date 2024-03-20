using SzpitalAPP.Person;
using Microsoft.EntityFrameworkCore;
namespace SzpitalAPP.Data
{
    public class SzpitalDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Patient> Patient => Set<Patient>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
