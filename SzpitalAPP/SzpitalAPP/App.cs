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
        
        public App(IDataGenerator dataGenerator, IUserCommunication userCommunication,ICsvReader csvReader)
        {
            _userCommunication = userCommunication;
            _dataGenerator = dataGenerator;
            _csvReader = csvReader;
        }
        public void Run()
        {
            var hospital = _csvReader.ProcessedHospitals("hospitals.csv");
            var local = _csvReader.ProcesedLocal("local.csv");
            var groups = hospital.GroupBy(h=> new
            {
                h.State
            },(key,g)=> new
            {
                state = key.State,
                city = g.Select(x=>x.City).ToList(),
                nip = g.Select(x => x.Nip).ToList(),
                regon = g.Select(x => x.Regon).ToList(),
                desc = g.Select(x => x.Desc).ToList(),
                expired = g.Select(x => x.ExpiryDate).ToList()
            });
            var document = new XDocument();
            var hospitalGroup = new XElement("Wojewodztwo", groups
                .Select(g =>
                new XElement("Hospital",
                new XAttribute("City", g.city),
                new XAttribute("NIP", g.nip),
                new XAttribute("regon", g.regon),
                new XAttribute("desc", g.desc),
                new XAttribute("Expired", g.expired)
                )));
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
           _dataGenerator.AddDoctors();
           _dataGenerator.AddPatients();
           _userCommunication.Task();

        }
    }
}
