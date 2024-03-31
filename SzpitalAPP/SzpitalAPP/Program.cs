using SzpitalAPP.Person;
using SzpitalAPP.Repository;
using SzpitalAPP.Data;
using System.Text.Json;


Console.WriteLine("Witaj w programie do obslugi bazy danych szpitala. Mozesz dodawac i usuwac dane o pracownikach i pacjentach!!!");
var employeeRepository = new SqlRepository<Employee>(new SzpitalDbContext());
var patientRepository = new SqlRepository<Patient>(new SzpitalDbContext());

const string employeeFilePath = "employeeRepository.json";
const string patientFilePath = "patientRepository.json";
const string employeeLogFilePath = "employeeRepositoryLog.txt";
const string patientLogFilePath = "patientRepositoryLog.txt";

void EventItemAdded<T>(object? sender, T item)
{
    if (item.GetType() == typeof(Employee))
    {
        File.AppendAllText(employeeLogFilePath, $"{DateTime.Now} - Added new employee - [{item}]\n");
    }
    else
    {
        File.AppendAllText(patientLogFilePath, $"{DateTime.Now} - Added new order - [{item}]\n");
    }
}

void EventItemRemoved<T>(object? sender, T item)
{
    if (item.GetType() == typeof(Employee))
    {
        File.AppendAllText(employeeLogFilePath, $"{DateTime.Now} - Employee deleted - [{item}]\n");
    }
    else
    {
        File.AppendAllText(patientLogFilePath, $"{DateTime.Now} - Order deleted - [{item}]\n");
    }
}

GetDataFromFile(employeeFilePath, employeeRepository);
GetDataFromFile(patientFilePath, patientRepository);

employeeRepository.ItemAdded += EventItemAdded;
employeeRepository.ItemRemoved += EventItemRemoved;
patientRepository.ItemAdded += EventItemAdded;
patientRepository.ItemRemoved += EventItemRemoved;

bool exitKey = false;
while (!exitKey)
{
    Console.WriteLine("1.Dodanie nowego pracownika szpitala");
    Console.WriteLine("2.Dodanie nowego pacjenta");
    Console.WriteLine("3.Usuniiecie pracownika szpitala");
    Console.WriteLine("4.Usuniecie pacjenta");
    Console.WriteLine("5 Odczyt wszytskich pracownikow");
    Console.WriteLine("6 Odczyt wszytkich pacjentow");
    Console.WriteLine("q wyjscie");
    var pressedKey = Console.ReadLine()?.Trim().ToUpper();
    switch (pressedKey)
    {
        case "1":
            AddEmployee();
            Console.WriteLine(" ");
            break;
        case "2":
            AddPatient();
            Console.WriteLine(" ");
            break;
        case "3":
            RemoveEmployee();
            Console.WriteLine(" ");
            break;
        case "4":
            RemovePatient();
            Console.WriteLine(" ");
            break;
        case "5":
            WriteAllEmployees();
            Console.WriteLine(" ");
            break;
        case "6":
            WriteAllPatients();
            Console.WriteLine(" ");
            break;
        case "Q":
            exitKey = true;
            break;
        default:
            Console.WriteLine("Blad: nie ma takiego polecenia");
            Console.WriteLine(" ");
            break;
    }
}
void AddEmployee()
{
    Console.WriteLine("Podaj imie pracownika:");
    var name = Console.ReadLine()?.ToUpper();
    Console.WriteLine("Podaj nazwisko pracownika:");
    var surname = Console.ReadLine()?.ToUpper();
    Console.WriteLine("Podaj pesel pracownika:");
    var pesel = Console.ReadLine()?.ToUpper();
    employeeRepository.Add(new Employee { Name = name, SurName = surname, Pesel = pesel });
    employeeRepository.Save();
    SaveDataToFile(employeeFilePath, employeeRepository);
}
void AddPatient()
{
    Console.WriteLine("Podaj imie pacjenta:");
    var name = Console.ReadLine()?.ToUpper();
    Console.WriteLine("Podaj nazwisko pacjenta:");
    var surname = Console.ReadLine()?.ToUpper();
    Console.WriteLine("Podaj pesel pacjenta:");
    var pesel = Console.ReadLine()?.ToUpper();
    patientRepository.Add(new Patient { Name = name, SurName = surname, Pesel = pesel });
    patientRepository.Save();
    SaveDataToFile (patientFilePath, patientRepository);
}
void RemoveEmployee()
{
    Console.WriteLine("Podaj pesel pracownika do usuniecia");
    var peselToRemove = Console.ReadLine()?.Trim().ToUpper();
    if (peselToRemove == null)
    {
        return;
    }
    var allEmployees = employeeRepository.GetAll().ToList();
    var employeeToRemove = allEmployees.FirstOrDefault(emp => emp.SurName == peselToRemove);
    if (employeeToRemove != null)
    {
        employeeRepository.Remove(employeeToRemove);
        employeeRepository.Save();
    }
}
void RemovePatient()
{
    Console.WriteLine("Podaj pesel pacjenta do usuniecia");
    var peselToRemove = Console.ReadLine()?.Trim().ToUpper();
    if (peselToRemove == null)
    {
        return;
    }
    var allPatients = patientRepository.GetAll().ToList();
    var patientToRemove = allPatients.FirstOrDefault(pat => pat.SurName == peselToRemove);
    if (patientToRemove != null)
    {
        patientRepository.Remove(patientToRemove);
        patientRepository.Save();
    }
}
void WriteAllEmployees()
{

    var items = employeeRepository.GetAll().ToList();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
void WriteAllPatients()
{
    var items = patientRepository.GetAll().ToList();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
void SaveDataToFile<T>(string filePath, SqlRepository<T> repository) where T : class, IPerson, new()
{
    var items = JsonSerializer.Serialize<List<T>>(repository.GetAll().ToList());

    File.WriteAllText(filePath, items);

    Console.WriteLine($"Zapisano:{items}");

    foreach (var item in repository.GetAll())
    {
        Console.WriteLine(item);
    }
}
void GetDataFromFile<T>(string filePath, SqlRepository<T> repository) where T : class, IPerson, new()
{
    if (File.Exists(filePath))
    {
        var items = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(filePath));

        if (items == null)
        {
            Console.WriteLine("Błąd odczytu danych z pliku", ConsoleColor.Red);
            return;
        }

        foreach (var item in items)
        {
            repository.Add(item);
        }

        repository.Save();
    }
}
