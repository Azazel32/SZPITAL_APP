using Microsoft.EntityFrameworkCore;
using SzpitalAPP.Data.Person;
using SzpitalAPP.Person;

namespace SzpitalAPP.Data
{
    public class SzpitalDbContext : DbContext
    {
        public SzpitalDbContext(DbContextOptions<SzpitalDbContext> options)
            :base(options) 
        {
        }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Hospital> hospitals { get; set;}
        public DbSet<Doctor> doctors { get; set; }
    }

 
}
