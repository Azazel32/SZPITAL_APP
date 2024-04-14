using Microsoft.Extensions.DependencyInjection;
using SzpitalAPP;
using SzpitalAPP.Repository;
using SzpitalAPP.Person;
using SzpitalAPP.Services;
using SzpitalAPP.Data;
using SzpitalAPP.DataProviders;

var services = new ServiceCollection();

services.AddSingleton<IRepository<Doctor>, RepositoryInFile<Doctor>>();
services.AddSingleton<IRepository<Patient>, RepositoryInFile<Patient>>();
services.AddSingleton<IApp,App>();
services.AddSingleton<IUserCommunication,UserComunication>();
services.AddSingleton<IDataGenerator, DataGenerator>();
services.AddSingleton<IPersonProvider,PersonProvider>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>();
app.Run();


