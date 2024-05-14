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
        public App(ICsvReader csvReader ,IDataGenerator dataGenerator, IUserCommunication userCommunication)
        {
            _userCommunication = userCommunication;
            _dataGenerator = dataGenerator;
            _csvReader = csvReader;
        }
        public void Run()
        {
            var hospitals = _csvReader.ProcessedHospitals("hospitals.csv");
            var local = _csvReader.ProcesedLocal("local.csv");
           _dataGenerator.AddDoctors();
           _dataGenerator.AddPatients();
           _userCommunication.Task();

        }
    }
}
