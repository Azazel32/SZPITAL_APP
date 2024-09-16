using SzpitalAPP.Data;
using SzpitalAPP.Data.Person;
using SzpitalAPP.Person;
namespace SzpitalAPP.Components.DataProviders
{
    public class DoctorProvider : IDoctorProvider
    {
        private readonly HospitalDbContext _szpitalDbContext;
        public DoctorProvider(HospitalDbContext szpitalDbContext)
        {
            _szpitalDbContext = szpitalDbContext;
        }
        public List<Doctor> GetDoctorsByAge()
        {
            return _szpitalDbContext.Doctors.OrderBy(x => x.Age).ToList();
        }

        public List<Doctor> GetDoctorsByBranch()
        {
            return _szpitalDbContext.Doctors.OrderBy(x => x.Branch).ToList();
        }

        public List<Doctor> GetDoctorsByCountry()
        {
            return _szpitalDbContext.Doctors.OrderBy(x => x.Country).ToList();
        }

        public List<Doctor> GetDoctorsByName()
        {
            return _szpitalDbContext.Doctors.OrderBy(x => x.Name).ThenBy(x => x.SurName).ToList();
        }

        public List<Doctor> GetDoctorsBySalary()
        {
            return _szpitalDbContext.Doctors.OrderBy(x => x.Salary).ToList();
        }

        public decimal GetMaxDoctorSalary()
        {
            return _szpitalDbContext.Doctors.Select(x => x.Salary).Max();
        }
        public List<Branch> GetUniqueBranch()
        {
            return _szpitalDbContext.Doctors.Select(x => x.Branch).Distinct().ToList();
        }

        public List<string> GetUniqueCity()
        {
            return _szpitalDbContext.Doctors.Select(x => x.City).Distinct().ToList();
        }

        public List<string> GetUniqueNationality()
        {
            return _szpitalDbContext.Doctors.Select(x => x.Country).Distinct().ToList();
        }
    }
}
