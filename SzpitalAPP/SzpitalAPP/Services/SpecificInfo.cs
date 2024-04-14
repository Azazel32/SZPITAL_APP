using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzpitalAPP.Data;

namespace SzpitalAPP.Services
{
    public class SpecificInfo : UserCommunicationBase, ISepecificinfo
    {
        private readonly IPersonProvider _personProvider;
        public SpecificInfo(IPersonProvider personProvider)
        {
            _personProvider = personProvider;
        }

        public void GetspecificInfo()
        {
            bool closeLoop = false;
            while (closeLoop)
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

                var choice = GetInputFromUser("Choose what you what do:");
                switch (choice)
                {
                    case "1":
                        GetUniqueNationality();

                        break;
                    case "2":
                        GetUniqueCity();
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
                        GetuniqueBranch();
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

        public override void Task()
        {
            throw new NotImplementedException();
        }
        public void GetUniqueNationality()
        {
            WritelineColor("Unique Nationality", ConsoleColor.Green);
            var uniqueNationality = _personProvider.GetUniqueNationality();
            foreach (var item in uniqueNationality) 
            {
                Console.WriteLine(item);
            }
        }
        public void GetUniqueCity()
        {
            WritelineColor("Unique City", ConsoleColor.Green);
            var uniqueCity = _personProvider.GetUniqueCity();
            foreach (var item in uniqueCity)
            {
                Console.WriteLine(item);
            }
        }
        public void GetMaxDoctorSalary() 
        {
            WritelineColor("Max Doctor Salary", ConsoleColor.Green);
            var MaxSalary = _personProvider.GetMaxDoctorSalary();
                Console.WriteLine(MaxSalary);
            
        }
        public void GetDoctorsByAge() 
        {
            WritelineColor("Doctors by age", ConsoleColor.Green);
            var doctorsByAge = _personProvider.GetDoctorsByAge();
            foreach (var item in doctorsByAge)
            {
                Console.WriteLine(item);
            }
        }
        public void GetDoctorsBySalary() 
        {
            WritelineColor("Doctors by Salary", ConsoleColor.Green);
            var doctorsBySalary = _personProvider.GetDoctorsBySalary();
            foreach (var item in doctorsBySalary)
            {
                Console.WriteLine(item);
            }
        }
        public void GetDoctorsByCountry()
        {
            WritelineColor("Doctors by city", ConsoleColor.Green);
            var doctorsByCity = _personProvider.GetDoctorsByCountry();
            foreach (var item in doctorsByCity)
            {
                Console.WriteLine(item);
            }
        }
        public void GetDoctorsByName() 
        {
            WritelineColor("Doctors by name", ConsoleColor.Green);
            var doctorsByName = _personProvider.GetDoctorsByName();
            foreach (var item in doctorsByName)
            {
                Console.WriteLine(item);
            }
        }
        public void GetDoctorsByBranch() 
        {
            WritelineColor("Doctors by branch", ConsoleColor.Green);
            var doctorsByBranch = _personProvider.GetDoctorsByAge();
            foreach (var item in doctorsByBranch)
            {
                Console.WriteLine(item);
            }
        }
        public void GetuniqueBranch() 
        {
            WritelineColor("Unique branch", ConsoleColor.Green);
            var uniqueBranch = _personProvider.GetUniqueBranch();
            foreach (var item in uniqueBranch)
            {
                Console.WriteLine(item);
            }
        }
    }

}
