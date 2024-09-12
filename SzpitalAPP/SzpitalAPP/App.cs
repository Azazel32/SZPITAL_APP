using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Xml.Linq;
using SzpitalAPP.Components.CSVReader;
using SzpitalAPP.Data;
using SzpitalAPP.Data.Person;
using SzpitalAPP.Person;
using SzpitalAPP.Repository;
using SzpitalAPP.Services;

namespace SzpitalAPP
{
    public class App : IApp
    {
        private readonly IDataGenerator _dataGenerator;
        private readonly IUserCommunication _userCommunication;
        private readonly ICsvReader _csvReader;
        private readonly SzpitalDbContext _szpitalDbContext;

        public App(IDataGenerator dataGenerator, IUserCommunication userCommunication, ICsvReader csvReader, SzpitalDbContext szpitalDbContext)
        {
            _userCommunication = userCommunication;
            _dataGenerator = dataGenerator;
            _csvReader = csvReader;
            _szpitalDbContext = szpitalDbContext;
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
            //ClearDataBase();
        }
        private void ClearDataBase()
        {
            var hosptalFromDb = _szpitalDbContext.hospitals.ToList();
            var patientsFromDb = _szpitalDbContext.patients.ToList();
            var doctorsFromDb = _szpitalDbContext.doctors.ToList();
            foreach (var item in hosptalFromDb)
            {
                _szpitalDbContext.hospitals.Remove(item);
            }
            foreach (var item in patientsFromDb)
            {
                _szpitalDbContext.patients.Remove(item);
            }
            foreach (var item in doctorsFromDb)
            {
                _szpitalDbContext.doctors.Remove(item);
            }
            _szpitalDbContext.SaveChanges();
        }
        private void LoadDateToDB()
        {
            var hosptalFromDb = _szpitalDbContext.hospitals.ToList();
            var patientsFromDb = _szpitalDbContext.patients.ToList();
            var doctorsFromDb = _szpitalDbContext.doctors.ToList();
            if (hosptalFromDb.IsNullOrEmpty())
            {
                var hospitals = _csvReader.ProcessedHospitals("Resources\\Files\\hospitals.csv");
                foreach (var hospital in hospitals)
                {
                    _szpitalDbContext.hospitals.Add(new Hospital()
                    {
                        Nip = hospital.Nip,
                        Regon = hospital.Regon,
                        Desc = hospital.Desc,
                        City = hospital.City,
                        Mark = hospital.Mark,
                        ExpiryDate = hospital.ExpiryDate,
                        AwardingDate = hospital.AwardingDate,
                        UrlAddress = hospital.UrlAddress
                    });

                }
            }
            var PatientFile = "PatientRepository.json";
            if (File.Exists(PatientFile)&& patientsFromDb.IsNullOrEmpty())
            {
                var patientText = File.ReadAllText(PatientFile);
                var patients = JsonSerializer.Deserialize<List<Patient>>(patientText);
                foreach (var item in patients)
                {
                    _szpitalDbContext.Add(new Patient()
                    { 
                        Name = item.Name,
                        SurName = item.SurName,
                        Pesel = item.Pesel,
                        Age = item.Age,
                        Branch = item.Branch,
                        City = item.City,
                        Country = item.Country,

                    });
                }
            }
            var DoctorFile = "DoctorRepository.json";
            if (File.Exists(DoctorFile)&& doctorsFromDb.IsNullOrEmpty())
            {
                var doctorText =File.ReadAllText(DoctorFile);
                var doctors=JsonSerializer.Deserialize<List<Doctor>>(doctorText);
                foreach(var item in doctors)
                {
                    _szpitalDbContext.Add(new Doctor()
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

            _szpitalDbContext.SaveChanges();
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
            var hospital = _csvReader.ProcessedHospitals("Resources\\Files\\hospitals.csv");
            var local = _csvReader.ProcesedLocal("Resources\\Files\\local.csv");

            var groupJoin = hospital.GroupJoin(local,
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
            var groups = hospital.GroupBy(x => x.City)
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
            var hospitalInCity = hospital.Join(local, x => x.City, x => x.City, (hospital, local) => new
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
            var hospitals = new XElement("Szpitale", hospital
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
