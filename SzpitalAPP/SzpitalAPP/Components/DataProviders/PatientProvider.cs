using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzpitalAPP.Data.Person;
using SzpitalAPP.Person;
using SzpitalAPP.Repository;

namespace SzpitalAPP.Components.DataProviders
{
    public class PatientProvider : IPatientProvider
    {
        private readonly IRepository<Patient> _patientRepository;
        public PatientProvider(IRepository<Patient> repository)
        {
            _patientRepository = repository;
        }

        public List<Patient> GetPatientsByAge()
        {
            var patients = _patientRepository.GetAll();
            return patients.OrderBy(p => p.Age).ToList();
        }

        public List<Patient> GetPatientsByBranch()
        {
            var patients = _patientRepository.GetAll();
            return patients.OrderBy(p => p.Branch).ToList();
        }

        public List<Patient> GetPatientsByCountry()
        {
            var patients = _patientRepository.GetAll();
            return patients.OrderBy(p => p.Country).ToList();
        }

        public List<Patient> GetPatientsByName()
        {
            var patients = _patientRepository.GetAll();
            return patients.OrderBy(p => p.Name).ToList();
        }
        public List<Branch> GetUniqueBranch()
        {
            var patients = _patientRepository.GetAll();
            return patients.Select(p => p.Branch).Distinct().ToList();
        }

        public List<string> GetUniqueCity()
        {
            var patients = _patientRepository.GetAll();
            return patients.Select(p => p.City).Distinct().ToList();
        }

        public List<string> GetUniqueNationality()
        {
            var patients = _patientRepository.GetAll();
            return patients.Select(p => p.Country).Distinct().ToList();
        }
    }
}
