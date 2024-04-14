
using SzpitalAPP.Person;
using SzpitalAPP.Repository;
using SzpitalAPP.Repository.Extensions;

namespace SzpitalAPP.Services
{
    public class DataGeneratorInFile : DataGenerator
    {
        
        private readonly IRepository<Doctor> _doctors;
        private readonly IRepository<Patient> _patients;
        public DataGeneratorInFile(IRepository<Doctor> employeeRepository,IRepository<Patient> patientRepository) 
        {
            _doctors = employeeRepository;
            _patients= patientRepository;
        }
        public override void AddDoctors()
        {
            _doctors.GetData();
            if(_doctors.CountList()==0)
            {
                var employess = GetDoctors();
                _doctors.AddBatch(employess);
            }
        }
        public override void AddPatients()
        {
            _patients.GetData();
            if( _patients.CountList()==0)
            {
                var patients =GetPatients();    
                _patients.AddBatch(patients);
            }

        }
    }
}
