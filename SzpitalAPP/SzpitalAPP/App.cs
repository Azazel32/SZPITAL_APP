using SzpitalAPP.Person;
using SzpitalAPP.Repository;

namespace SzpitalAPP
{
    public class App : IApp
    {
        public void Run()
        {
            const string employeeFilePath = "employeeRepository.json";
            const string patientFilePath = "patientRepository.json";
            Console.WriteLine("Witaj w programie do obslugi bazy danych szpitala. Mozesz dodawac i usuwac dane o pracownikach i pacjentach!!!");
            var employeeRepository = new RepositoryInFile<Employee>(employeeFilePath);
            var patientRepository = new RepositoryInFile<Patient>(patientFilePath);
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
                var employeeToRemove = allEmployees.FirstOrDefault(emp => emp.Pesel == peselToRemove);
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
        }
    }
}
