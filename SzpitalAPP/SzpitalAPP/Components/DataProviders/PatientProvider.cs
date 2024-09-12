using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzpitalAPP.Components.CSVReader.Models;
using SzpitalAPP.Data;
using SzpitalAPP.Data.Person;
using SzpitalAPP.Person;
using SzpitalAPP.Repository;

namespace SzpitalAPP.Components.DataProviders
{
    public class PatientProvider : IPatientProvider
    {

        private readonly SzpitalDbContext _szpitalDbContext;
        public PatientProvider(SzpitalDbContext szpitalDbContext)
        {

            _szpitalDbContext = szpitalDbContext;
        }


        public List<Patient> GetPatientsByAge()
        {
            var p = _szpitalDbContext.patients.OrderBy(p => p.Age);

            return p.ToList();
        }

        public List<Patient> GetPatientsByBranch()
        {

            return _szpitalDbContext.patients.OrderBy(p => p.Branch).ToList();
        }

        public List<Patient> GetPatientsByCountry()
        {

            return _szpitalDbContext.patients.OrderBy(p => p.Country).ToList();
        }

        public List<Patient> GetPatientsByName()
        {

            return _szpitalDbContext.patients.OrderBy(p => p.Name).ToList();
        }
        public List<Branch> GetUniqueBranch()
        {

            return _szpitalDbContext.patients.Select(p => p.Branch).Distinct().ToList();
        }

        public List<string> GetUniqueCity()
        {

            return _szpitalDbContext.patients.Select(p => p.City).Distinct().ToList();
        }

        public List<string> GetUniqueNationality()
        {

            return _szpitalDbContext.patients.Select(p => p.Country).Distinct().ToList();
        }


    }
}
