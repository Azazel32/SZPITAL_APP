using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzpitalAPP.Data.Person;
using SzpitalAPP.Person;

namespace SzpitalAPP.Components.DataProviders
{
    public interface IDoctorProvider
    {
        List<string> GetUniqueNationality();
        List<string> GetUniqueCity();
        decimal GetMaxDoctorSalary();
        List<Doctor> GetDoctorsByAge();
        List<Doctor> GetDoctorsBySalary();
        List<Doctor> GetDoctorsByCountry();
        List<Doctor> GetDoctorsByName();
        List<Doctor> GetDoctorsByBranch();
        List<Branch> GetUniqueBranch();
    }
}
