using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzpitalAPP.Components.DataProviders;
using SzpitalAPP.Person;

namespace SzpitalAPP.Services
{
    public class SpecificInfo : UserCommunicationBase, ISepecificinfo
    {
        private readonly IDoctorProvider _doctorProvider;
        private readonly IPatientProvider _patientProvider;
        
        
        public SpecificInfo(IDoctorProvider doctorProvider, IPatientProvider patientProvider)
        {
            _doctorProvider = doctorProvider;
            _patientProvider = patientProvider;
            
        }
        
        public void GetspecificInfoForDoctor()
        {
            bool closeLoop = false;
            while (!closeLoop)
            {
                WritelineColor("----Specific Info----\n+" +
                    "1. Get unique National\n" +
                    "2. Get unique City\n" +
                    "3. Get max docktor's Salary\n" +
                    "4. Order doctors by age\n" +
                    "5. Order doctors by salary\n" +
                    "6. Order doctors by country\n" +
                    "7. Order doctors by name\n" +
                    "8. Order doctors by branch\n" +
                    "9. Order unique branch\n" +
                    "q. exit\n", ConsoleColor.Cyan);

                var choice = GetInputFromUser("Choose what you what do:").ToUpper();
                switch (choice)
                {
                    case "1":
                        GetUniqueNationalityForDoctor();

                        break;
                    case "2":
                        GetUniqueCityForDoctor();
                        break;
                    case "3":
                        GetMaxDoctorSalary();
                        break;
                    case "4":
                        GetDoctorsByAge();
                        break;
                    case "5":
                        GetDoctorsBySalary();
                        break;
                    case "6":
                        GetDoctorsByCountry();
                        break;
                    case "7":
                        GetDoctorsByName();
                        break;
                    case "8":
                        GetDoctorsByBranch();
                        break;
                    case "9":
                        GetuniqueBranchForDoctor();
                        break;
                    case "Q":
                        closeLoop=true;
                        break;
                    default:
                        WritelineColor("invalid Operation", ConsoleColor.Red);
                        continue;

                }
            }
        }
        public void GetspecificInfoForPatient()
        {
            bool closeLoop = false;
            while (!closeLoop)
            {
                WritelineColor("----Specific Info----\n+" +
                    "1. Get unique National\n" +
                    "2. Get unique City\n" +
                    "3. Order patients by age\n" +
                    "4. Order patients by country\n" +
                    "5. Order patients by name\n" +
                    "6. Order patients by branch\n" +
                    "7. Order unique branch\n" +
                    "q. exit\n", ConsoleColor.Cyan);

                var choice = GetInputFromUser("Choose what you what do:").ToUpper();
                switch (choice)
                {
                    case "1":
                        GetUniqueNationalityForPatients();
                        break;
                    case "2":
                        GetUniqueCityForPatients();
                        break;
                    case "3":
                        GetPatientsByAge();
                        break;
                    case "4":
                        GetPatientsByCountry();
                        break;
                    case "5":
                        GetPatientsByName();
                        break;
                    case "6":
                        GetPatientsByBranch();
                        break;
                    case "7":
                        GetUniqueBranchForPatients();
                        break;
                    case "Q":
                        closeLoop = true;
                        break;
                    default:
                        WritelineColor("invalid Operation", ConsoleColor.Red);
                        continue;

                }
            }
        }
        
        public override void Task()
        {
            throw new NotImplementedException();
        }
        public void GetUniqueNationalityForDoctor()
        {
            WritelineColor("Unique Nationality", ConsoleColor.Green);
            var uniqueNationality = _doctorProvider.GetUniqueNationality();
            foreach (var item in uniqueNationality) 
            {
                Console.WriteLine(item);
            }
        }
        public void GetUniqueCityForDoctor()
        {
            WritelineColor("Unique City", ConsoleColor.Green);
            var uniqueCity = _doctorProvider.GetUniqueCity();
            foreach (var item in uniqueCity)
            {
                Console.WriteLine(item);
            }
        }
        public void GetMaxDoctorSalary() 
        {
            WritelineColor("Max Doctor Salary", ConsoleColor.Green);
            var MaxSalary = _doctorProvider.GetMaxDoctorSalary();
                Console.WriteLine(MaxSalary);
            
        }
        public void GetDoctorsByAge() 
        {
            WritelineColor("Doctors by age", ConsoleColor.Green);
            var doctorsByAge = _doctorProvider.GetDoctorsByAge();
            foreach (var item in doctorsByAge)
            {
                Console.WriteLine(item);
            }
        }
        public void GetDoctorsBySalary() 
        {
            WritelineColor("Doctors by Salary", ConsoleColor.Green);
            var doctorsBySalary = _doctorProvider.GetDoctorsBySalary();
            foreach (var item in doctorsBySalary)
            {
                Console.WriteLine(item);
            }
        }
        public void GetDoctorsByCountry()
        {
            WritelineColor("Doctors by city", ConsoleColor.Green);
            var doctorsByCity = _doctorProvider.GetDoctorsByCountry();
            foreach (var item in doctorsByCity)
            {
                Console.WriteLine(item);
            }
        }
        public void GetDoctorsByName() 
        {
            WritelineColor("Doctors by name", ConsoleColor.Green);
            var doctorsByName = _doctorProvider.GetDoctorsByName();
            foreach (var item in doctorsByName)
            {
                Console.WriteLine(item);
            }
        }
        public void GetDoctorsByBranch() 
        {
            WritelineColor("Doctors by branch", ConsoleColor.Green);
            var doctorsByBranch = _doctorProvider.GetDoctorsByAge();
            foreach (var item in doctorsByBranch)
            {
                Console.WriteLine(item);
            }
        }
        public void GetuniqueBranchForDoctor() 
        {
            WritelineColor("Unique branch", ConsoleColor.Green);
            var uniqueBranch = _doctorProvider.GetUniqueBranch();
            foreach (var item in uniqueBranch)
            {
                Console.WriteLine(item);
            }
        }
        public void GetUniqueBranchForPatients()
        {
            WritelineColor("Unique branch", ConsoleColor.Green);
            var uniqueBranch = _patientProvider.GetUniqueBranch();
            foreach (var item in uniqueBranch)
            {
                Console.WriteLine(item);
            }
        }
        public void GetUniqueNationalityForPatients()
        {
            WritelineColor("Unqiue Country",ConsoleColor.Green);
            var uniqueCountry= _patientProvider.GetUniqueNationality();
            foreach (var item in uniqueCountry)
            { Console.WriteLine(item); }
        }
        public void GetUniqueCityForPatients()
        {
            WritelineColor("Unqiue City", ConsoleColor.Green);
            var uniqueCity = _patientProvider.GetUniqueCity();
            foreach (var item in uniqueCity)
            { Console.WriteLine(item); }
        }
        public void GetPatientsByName()
        {
            WritelineColor("Patinets by Name", ConsoleColor.Green);
            var patientsByName= _patientProvider.GetPatientsByName();
            foreach (var item in patientsByName)
            {
                Console.WriteLine(item);
            }
        }
        public void GetPatientsByAge()
        {
            WritelineColor("Patients by Age", ConsoleColor.Green);
            var patientsByAge= _patientProvider.GetPatientsByAge();
            foreach (var item in patientsByAge)
            {
                Console.WriteLine(item);
            }
        }
        public void GetPatientsByBranch()
        {
            WritelineColor("Patients by branch", ConsoleColor.Green);
            var patientsByBranch = _patientProvider.GetPatientsByAge();
            foreach (var item in patientsByBranch)
            {
                Console.WriteLine(item);
            }
        }
        public void GetPatientsByCountry()
        {
            WritelineColor("Patients by Country", ConsoleColor.Green);
            var patinetsByCountry=_patientProvider.GetPatientsByCountry();
            foreach (var item in patinetsByCountry)
            {
                Console.WriteLine(item);
            }
        }

    }

}
