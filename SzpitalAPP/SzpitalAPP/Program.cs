using Microsoft.Extensions.DependencyInjection;
using SzpitalAPP;
using SzpitalAPP.Repository;
using SzpitalAPP.Person;
using SzpitalAPP.Services;
using SzpitalAPP.Components.DataProviders;
using SzpitalAPP.Components.CSVReader;
using SzpitalAPP.Data;
using Microsoft.EntityFrameworkCore;


var services = new ServiceCollection();
services.AddSingleton<IApp,App>();
services.AddSingleton<IUserCommunication,UserComunication>();
services.AddSingleton<IDoctorProvider, DoctorProvider>();
services.AddSingleton<IPatientProvider,PatientProvider>();
services.AddSingleton<ISepecificinfo,SpecificInfo>();
services.AddSingleton<IRepository<Doctor>, SqlRepository<Doctor>>();
services.AddSingleton<IRepository<Patient>, SqlRepository<Patient>>();
services.AddSingleton<IDataGenerator, UploadDataToFile>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddDbContext<HospitalDbContext>(options=>options.UseSqlServer("Data Source=DESKTOP-LIC9HF3\\SQLEXPRESS;Initial Catalog=HospitalStorage;Integrated Security=True; TrustServerCertificate=True"));


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>();
app.Run();


