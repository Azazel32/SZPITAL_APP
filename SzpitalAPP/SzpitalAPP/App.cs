using SzpitalAPP.Data.Person;
using SzpitalAPP.Repository;
using SzpitalAPP.Services;

namespace SzpitalAPP
{
    public class App : IApp
    {
        private readonly IDataGenerator _dataGenerator;
        private readonly IUserCommunication _userCommunication;
        public App(IDataGenerator dataGenerator, IUserCommunication userCommunication)
        {
            _userCommunication = userCommunication;
            _dataGenerator = dataGenerator;
        }
        public void Run()
        {
           _dataGenerator.AddDoctors();
           _dataGenerator.AddPatients();
           _userCommunication.Task();

        }
    }
}
