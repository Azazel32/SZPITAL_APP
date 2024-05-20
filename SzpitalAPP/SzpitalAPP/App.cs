using System.Runtime.CompilerServices;
using System.Xml.Linq;
using SzpitalAPP.Components.CSVReader;
using SzpitalAPP.Data.Person;
using SzpitalAPP.Repository;
using SzpitalAPP.Services;

namespace SzpitalAPP
{
    public class App : IApp
    {
        private readonly IDataGenerator _dataGenerator;
        private readonly IUserCommunication _userCommunication;
        private readonly ICsvReader _csvReader;

        public App(IDataGenerator dataGenerator, IUserCommunication userCommunication, ICsvReader csvReader)
        {
            _userCommunication = userCommunication;
            _dataGenerator = dataGenerator;
            _csvReader = csvReader;
        }
        public void Run()
        {
            CreateXml();
            QueryXml();
            _dataGenerator.AddDoctors();
            _dataGenerator.AddPatients();
            _userCommunication.Task();
            
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
                }
            );
            var document = new XDocument();

            var hospitalGroup = new XElement("Szpitale", groups
               .Select(x => new XElement("Województwo",
               new XAttribute("Ilość", x.Count)
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
