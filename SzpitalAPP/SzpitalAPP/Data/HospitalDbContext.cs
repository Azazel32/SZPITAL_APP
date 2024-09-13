using Microsoft.EntityFrameworkCore;
using SzpitalAPP.Data.Person;
using SzpitalAPP.Person;

namespace SzpitalAPP.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
            :base(options) 
        {
        }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Doctor> doctors { get; set; }
    }

 
}
