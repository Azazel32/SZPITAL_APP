
using SzpitalAPP.Data.Person;
using SzpitalAPP.Person;

namespace SzpitalAPP.Services
{
    public abstract class DataGenerator : IDataGenerator
    {
        public abstract void AddDoctors();
        public abstract void AddPatients();
        protected IEnumerable<Doctor> GetDoctors()
        {
            var doctors = new List<Doctor>()
            {
                new Doctor()
                {
                    Name = "Marek",
                    SurName ="Kowal",
                    Pesel="1523467985",
                    Age =45,
                    City = "Warszawa",
                    Country="Polska",
                    Branch = Branch.Cardiology,
                    Salary=6_300,
                },
                new Doctor()
                {
                    Name = "Damian",
                    SurName ="Nos",
                    Pesel="9365024631",
                    Age =34,
                    City = "Warszawa",
                    Country="Polska",
                    Branch = Branch.Gastrology,
                    Salary=10_000,
                },
                new Doctor()
                {
                    Name = "Lukasz",
                    SurName ="Maj",
                    Pesel="2956748421",
                    Age =54,
                    City = "Kielce",
                    Country="Polska",
                    Branch = Branch.Pulmonology,
                    Salary=9_000,
                },
                new Doctor()
                {
                    Name = "Zbigniew",
                    SurName ="Mural",
                    Pesel="9360936483",
                    Age =37,
                    City = "Krakow",
                    Country="Polska",
                    Branch = Branch.Ortopedics,
                    Salary=10_000,
                },
                new Doctor()
                {
                    Name = "Hubert",
                    SurName ="Hans",
                    Pesel="562345024567",
                    Age =29,
                    City = "Berlin",
                    Country="Niemcy",
                    Branch = Branch.OIOM,
                    Salary=15_000,
                }
            };
            
            
            return doctors;
        }
        protected IEnumerable<Patient> GetPatients() 
        {
            var patients = new List<Patient>()
            {
                new Patient()
                {
                    Name = "Jakub",
                    SurName="Szela",
                    Pesel="12983649018",
                    Age=29,
                    City="Katowice",
                    Country="Polska",
                    Branch=Branch.Pulmonology
                },
                new Patient() 
                {
                    Name = "Dawid",
                    SurName="Szproch",
                    Pesel="1298334538",
                    Age=18,
                    City="Kielce",
                    Country="Polska",
                    Branch=Branch.Gastrology
                },
                new Patient()
                {
                    Name = "Kacper",
                    SurName="Borowiec",
                    Pesel="1298334728",
                    Age=15,
                    City="Warszawa",
                    Country="Polska",
                    Branch=Branch.OIOM
                },
                new Patient()
                {
                    Name = "Marcin",
                    SurName="Jakubwski",
                    Pesel="1295634018",
                    Age=29,
                    City="Pozan",
                    Country="Polska",
                    Branch=Branch.Cardiology
                }

            };  
            return patients;
        }
    }
    
}
