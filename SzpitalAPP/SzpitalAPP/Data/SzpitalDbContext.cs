using Microsoft.EntityFrameworkCore;
using SzpitalAPP.Data.Person;
using SzpitalAPP.Person;

namespace SzpitalAPP.Data
{
    public class SzpitalDbContext : DbContext
    {
        public DbSet<Doctor> Employee => Set<Doctor>();
        public DbSet<Patient> Patient => Set<Patient>();
          

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
