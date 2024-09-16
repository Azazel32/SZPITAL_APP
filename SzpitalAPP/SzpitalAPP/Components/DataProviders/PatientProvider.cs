using SzpitalAPP.Data;
using SzpitalAPP.Data.Person;
using SzpitalAPP.Person;
namespace SzpitalAPP.Components.DataProviders
{
    public class PatientProvider : IPatientProvider
    {
        private readonly HospitalDbContext _szpitalDbContext;
        public PatientProvider(HospitalDbContext szpitalDbContext)
        {

            _szpitalDbContext = szpitalDbContext;
        }
        public List<Patient> GetPatientsByAge()
        {
            return _szpitalDbContext.Patients.OrderBy(p => p.Age).ToList();
        }

        public List<Patient> GetPatientsByBranch()
        {
            return _szpitalDbContext.Patients.OrderBy(p => p.Branch).ToList();
        }

        public List<Patient> GetPatientsByCountry()
        {
            return _szpitalDbContext.Patients.OrderBy(p => p.Country).ToList();
        }

        public List<Patient> GetPatientsByName()
        {
            return _szpitalDbContext.Patients.OrderBy(p => p.Name).ToList();
        }

        public List<Branch> GetUniqueBranch()
        {
            return _szpitalDbContext.Patients.Select(p => p.Branch).Distinct().ToList();
        }

        public List<string> GetUniqueCity()
        {
            return _szpitalDbContext.Patients.Select(p => p.City).Distinct().ToList();
        }

        public List<string> GetUniqueNationality()
        {
            return _szpitalDbContext.Patients.Select(p => p.Country).Distinct().ToList();
        }
    }
}
