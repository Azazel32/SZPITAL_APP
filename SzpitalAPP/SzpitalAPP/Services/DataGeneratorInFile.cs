
using SzpitalAPP.Person;
using SzpitalAPP.Repository;

namespace SzpitalAPP.Services
{
    public class DataGeneratorInFile : DataGenerator
    {
        private readonly IRepository<Employee> _employees;
        private readonly IRepository<Patient> _patients;
        public DataGeneratorInFile(IRepository<Employee> employeeRepository,IRepository<Patient> patientRepository) 
        {
            _employees = employeeRepository;
            _patients= patientRepository;
        }
        public void AdEmployess()
        {
            if(_employees.)
            {

            }
        }
        public void AddPatients()
        {

        }
    }
}
