using Microsoft.Extensions.DependencyInjection;
using SzpitalAPP;
using SzpitalAPP.Repository;
using SzpitalAPP.Person;
using SzpitalAPP.Services;
using SzpitalAPP.Components.DataProviders;
using SzpitalAPP.Components.CSVReader;

var services = new ServiceCollection();
services.AddSingleton<IApp,App>();
services.AddSingleton<IUserCommunication,UserComunication>();
services.AddSingleton<IDoctorProvider, DoctorProvider>();
services.AddSingleton<IPatientProvider,PatientProvider>();
services.AddSingleton<ISepecificinfo,SpecificInfo>();
services.AddSingleton<IRepository<Doctor>, RepositoryInFile<Doctor>>();
services.AddSingleton<IRepository<Patient>, RepositoryInFile<Patient>>();
services.AddSingleton<IDataGenerator, DataGeneratorInFile>();
services.AddSingleton<ICsvReader, CsvReader>();


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>();
app.Run();


