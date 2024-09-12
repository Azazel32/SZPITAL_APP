using System;
using System.Collections.Generic;
using SzpitalAPP.Data;
using SzpitalAPP.Data.Person;
using SzpitalAPP.Person;
using SzpitalAPP.Repository;

namespace SzpitalAPP.Components.DataProviders
{
    public class DoctorProvider : IDoctorProvider
    {

        private readonly SzpitalDbContext _szpitalDbContext;
        public DoctorProvider(SzpitalDbContext szpitalDbContext)
        {
            _szpitalDbContext = szpitalDbContext;
        }
        public List<Doctor> GetDoctorsByAge()
        {

            return _szpitalDbContext.doctors.OrderBy(x => x.Age).ToList();
        }

        public List<Doctor> GetDoctorsByBranch()
        {

            return _szpitalDbContext.doctors.OrderBy(x => x.Branch).ToList();
        }

        public List<Doctor> GetDoctorsByCountry()
        {

            return _szpitalDbContext.doctors.OrderBy(x => x.Country).ToList();
        }

        public List<Doctor> GetDoctorsByName()
        {

            return _szpitalDbContext.doctors.OrderBy(x => x.Name).ThenBy(x => x.SurName).ToList();
        }

        public List<Doctor> GetDoctorsBySalary()
        {

            return _szpitalDbContext.doctors.OrderBy(x => x.Salary).ToList();
        }

        public decimal GetMaxDoctorSalary()
        {

            return _szpitalDbContext.doctors.Select(x => x.Salary).Max();
        }
        public List<Branch> GetUniqueBranch()
        {

            return _szpitalDbContext.doctors.Select(x => x.Branch).Distinct().ToList();
        }

        public List<string> GetUniqueCity()
        {

            return _szpitalDbContext.doctors.Select(x => x.City).Distinct().ToList();
        }

        public List<string> GetUniqueNationality()
        {

            return _szpitalDbContext.doctors.Select(x => x.Country).Distinct().ToList();
        }
    }
}
