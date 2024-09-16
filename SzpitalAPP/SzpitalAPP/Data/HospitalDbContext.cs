using Microsoft.EntityFrameworkCore;
using SzpitalAPP.Person;
namespace SzpitalAPP.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
            :base(options) 
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
