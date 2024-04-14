using Microsoft.Extensions.DependencyInjection;
using SzpitalAPP;
using SzpitalAPP.Repository;
using SzpitalAPP.Person;
using SzpitalAPP.Services;
using SzpitalAPP.Data;
using SzpitalAPP.DataProviders;

var services = new ServiceCollection();
services.AddSingleton<IApp,App>();
services.AddSingleton<IUserCommunication,UserComunication>();
services.AddSingleton<IPersonProvider,PersonProvider>();
services.AddSingleton<ISepecificinfo,SpecificInfo>();
services.AddSingleton<IRepository<Doctor>, RepositoryInFile<Doctor>>();
services.AddSingleton<IRepository<Patient>, RepositoryInFile<Patient>>();
services.AddSingleton<IDataGenerator, DataGeneratorInFile>();


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>();
app.Run();


