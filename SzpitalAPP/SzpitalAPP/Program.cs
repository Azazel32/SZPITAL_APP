using SzpitalAPP.Person;
using SzpitalAPP.Repository;
using Microsoft.Extensions.DependencyInjection;
using SzpitalAPP.DataProviders.Extensions;
using SzpitalAPP;

var services = new ServiceCollection();
services.AddSingleton <IDoctors, Doctors>();
services.AddSingleton<IRepository<Employee>, RepositoryInFile<Employee>>();
services.AddSingleton<IRepository<Patient>, RepositoryInFile<Patient>>();
services.AddSingleton<IApp,App>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>();
app.Run();


