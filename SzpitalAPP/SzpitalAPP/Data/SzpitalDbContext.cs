using Microsoft.EntityFrameworkCore;
using SzpitalAPP.Data.Person;

namespace SzpitalAPP.Data
{
    public class SzpitalDbContext : DbContext
    {
        public DbSet<Employee> Employee => Set<Employee>();
        public DbSet<Patient> Patient => Set<Patient>();
          

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
