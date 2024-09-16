using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using System.Xml.Linq;
using SzpitalAPP.Components.CSVReader;
using SzpitalAPP.Data;
using SzpitalAPP.Person;
using SzpitalAPP.Services;

namespace SzpitalAPP
{
    public class App : IApp
    {
        private readonly IDataGenerator _dataGenerator;
        private readonly IUserCommunication _userCommunication;
        private readonly ICsvReader _csvReader;
        private readonly HospitalDbContext _hospitalDbContext;
        public App(IDataGenerator dataGenerator, IUserCommunication userCommunication, ICsvReader csvReader, HospitalDbContext szpitalDbContext)
        {
            _userCommunication = userCommunication;
            _dataGenerator = dataGenerator;
            _csvReader = csvReader;
            _hospitalDbContext = szpitalDbContext;
            szpitalDbContext.Database.EnsureCreated();
        }
        public void Run()
        {
            //CreateXml();
            //QueryXml();
            _dataGenerator.AddDoctors();
            _dataGenerator.AddPatients();
            LoadDateToDB();
            _userCommunication.Task();
        }
        
        private void LoadDateToDB()
        {
            var patientsFromDb = _hospitalDbContext.Patients.ToList();
            var doctorsFromDb = _hospitalDbContext.Doctors.ToList();
            var PatientFileName = "PatientRepository.json";
            if (File.Exists(PatientFileName)&& patientsFromDb.IsNullOrEmpty())
            {
                var patientText = File.ReadAllText(PatientFileName);
                var patients = JsonSerializer.Deserialize<List<Patient>>(patientText);
                foreach (var item in patients)
                {
                    _hospitalDbContext.Add(new Patient()
                    { 
                        Name = item.Name,
                        SurName = item.SurName,
                        Pesel = item.Pesel,
                        Age = item.Age,
                        Branch = item.Branch,
                        City = item.City,
                        Country = item.Country
                    });
                }
            }
            var DoctorFileName = "DoctorRepository.json";
            if (File.Exists(DoctorFileName)&& doctorsFromDb.IsNullOrEmpty())
            {
                var doctorText =File.ReadAllText(DoctorFileName);
                var doctors=JsonSerializer.Deserialize<List<Doctor>>(doctorText);
                foreach(var item in doctors)
                {
                    _hospitalDbContext.Add(new Doctor()
                    {
                        Name = item.Name,
                        SurName = item.SurName,
                        Pesel = item.Pesel,
                        Age = item.Age,
                        Branch = item.Branch,
                        City = item.City,
                        Country = item.Country,
                        Salary = item.Salary
                    });
                }
            }

            _hospitalDbContext.SaveChanges();
        }

        private static void QueryXml()
        {
            var document = XDocument.Load("HospitalInCity.xml");
            var Names = document.Element("Hospitals")?.Elements("Hospital").Select(x => x.Attribute("Desc")?.Value);
            foreach (var item in Names)
            {
                Console.WriteLine(item);
            }
        }

        private void CreateXml()
        {
            var processedHospital = _csvReader.ProcessedHospitals("Resources\\Files\\hospitals.csv");
            var processedLocalizaton = _csvReader.ProcesedLocal("Resources\\Files\\local.csv");

            var groupJoin = processedHospital.GroupJoin(processedLocalizaton,
                hospital => hospital.City,
                local => local.City,
                (key, g) =>
                new
                {
                    local = key,
                    hospital = g
                });
            foreach (var group in groupJoin)
            {
                Console.WriteLine($"Miasto: {group.local.City}");
                Console.WriteLine($"Ilosc:{group.hospital.Count()}");
            }
            var groups = processedHospital.GroupBy(x => x.City)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Select(c => c.Nip).Count(),
                    City = g.Select(c => c.Nip)
                }
            );
            var document = new XDocument();

            var hospitalGroup = new XElement("Szpitale", groups
               .Select(x => new XElement("Miasto",
               new XAttribute("Ilość", x.Count),
               new XAttribute("Miasto", x.Name)
                   )));
            var hospitalInCity = processedHospital.Join(processedLocalizaton, x => x.City, x => x.City, (hospital, local) => new
            {
                local.State,
                hospital.Desc,
                hospital.Nip
            });
            var documnet3 = new XDocument();
            var hospitalInCityToXml = new XElement("Hospitals", hospitalInCity
                .Select(x => new XElement("Hospital",
                new XAttribute("Woj", x.State),
                new XAttribute("Desc", x.Desc),
                new XAttribute("Nip", x.Nip))));
            var document2 = new XDocument();
            var hospitals = new XElement("Szpitale", processedHospital
                .Select(g =>
                new XElement("Hospital",
                new XAttribute("City", g.City),
                new XAttribute("NIP", g.Nip),
                new XAttribute("regon", g.Regon),
                new XAttribute("desc", g.Desc),
                new XAttribute("Expired", g.ExpiryDate)
                )));
            document2.Add(hospitals);
            document2.Save("szpitale.xml");
            document.Add(hospitalGroup);
            document.Save("hospitalGroup.xml");
            documnet3.Add(hospitalInCityToXml);
            documnet3.Save("HospitalInCity.xml");
        }
    }
}
