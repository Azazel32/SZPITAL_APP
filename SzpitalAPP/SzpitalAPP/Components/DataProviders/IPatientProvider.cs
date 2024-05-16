using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzpitalAPP.Components.CSVReader.Models;
using SzpitalAPP.Data.Person;
using SzpitalAPP.Person;

namespace SzpitalAPP.Components.DataProviders
{
    public interface IPatientProvider
    {
        List<string> GetUniqueNationality();
        List<string> GetUniqueCity();
        List<Patient> GetPatientsByAge();
        List<Patient> GetPatientsByCountry();
        List<Patient> GetPatientsByName();
        List<Patient> GetPatientsByBranch();
        List<Branch> GetUniqueBranch();
        
    }
}
