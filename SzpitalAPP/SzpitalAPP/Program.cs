using SzpitalAPP.Person;
using SzpitalAPP.Repository;
using SzpitalAPP.Data;
var sqlRepository = new SqlRepository<Employee>(new SzpitalDbContext());


AddEmployees(sqlRepository);
AddDoctors(sqlRepository);
WriteAllToConsole(sqlRepository);

static void AddEmployees(IWriteRepository<Employee> sqlRepository)
{
    sqlRepository.Add(new Employee { Name = "Rafal", SurName = "Kowal" });
    sqlRepository.Add(new Employee { Name = "Maciej", SurName = "Nowak" });
    sqlRepository.Add(new Employee { Name = "Jakub", SurName = "Molenda" });
    sqlRepository.Save();
}

static void AddDoctors(IWriteRepository<Doctor> sqlRepository)
{
    sqlRepository.Add(new Doctor { Name = "Dawid", SurName = "Kowal" });
    sqlRepository.Add(new Doctor { Name = "Michal", SurName = "Nowak" });
    sqlRepository.Add(new Doctor { Name = "Damian", SurName = "Molenda" });
    sqlRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IPerson> sqlRepository)
{
    var items = sqlRepository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

