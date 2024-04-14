
using SzpitalAPP.Person;

namespace SzpitalAPP.Services
{
    public abstract class DataGenerator : IDataGenerator
    {
        public abstract void AddDoctors();
        public abstract void AddPatients();
        protected IEnumerable<Doctor> GetDoctors()
        {
            var employees = new List<Doctor>();
            return employees;
        }
        protected IEnumerable<Patient> GetPatients() 
        {
            var patients = new List<Patient>();
            return patients;
        }
    }
    
}
