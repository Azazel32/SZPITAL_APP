using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzpitalAPP.Person;
using SzpitalAPP.Repository;

namespace SzpitalAPP.Services
{
    public class UserComunication : UserCommunicationBase
    {
        private readonly IRepository<Doctor> _doctors;
        private readonly IRepository<Patient> _patients;

        public UserComunication(IRepository<Doctor> doctorsReposiotry, IRepository<Patient> patientsRepository)
        {
            _doctors = doctorsReposiotry;
            _patients = patientsRepository;
        }
        public override void Task()
        {
            bool Close = false;
            while (!Close)
            {
                const string employeeFilePath = "employeeRepository.json";
                const string patientFilePath = "patientRepository.json";
                Console.WriteLine("Witaj w programie do obslugi bazy danych szpitala. Mozesz dodawac i usuwac dane o pracownikach i pacjentach!!!");
                var employeeRepository = new RepositoryInFile<Doctor>(employeeFilePath);
                var patientRepository = new RepositoryInFile<Patient>(patientFilePath);
                bool exitKey = false;
                while (!exitKey)
                {
                    Console.WriteLine("1.Add new person");
                    Console.WriteLine("2.Remove person from memory");
                    Console.WriteLine("3.Find person by ID");
                    Console.WriteLine("4.Show all person");
                    Console.WriteLine("5.Get specific inforamtion");
                    Console.WriteLine("q wyjscie");
                    var userInput = GetInputFromUser("What do you want to do? \n").ToUpper();
                    switch (userInput)
                    {
                        case "1":
                            var userChoiceToAdd = GetInputFromUser("Add Person - Press D to choice Doctor or press P to choice Patient").ToUpper();
                            if (userChoiceToAdd == "D")
                            {
                                AddDoctor();
                                break;
                            }
                            else if (userChoiceToAdd == "P")
                            {
                                AddPatient();
                                break;
                            }
                            break;
                        case "2":
                            var userChoiceToRemove = GetInputFromUser("Remove Person - Press D to choice Doctor or press P to choice Patient").ToUpper();
                            if (userChoiceToRemove == "D")
                            {
                                RemovePerson(_doctors);
                                break;
                            }
                            else if (userChoiceToRemove == "P")
                            {
                                RemovePerson(_patients);
                                break;
                            }
                            break;
                        case "3":
                            var choicePersonById = GetInputFromUser("Find By Id - Press D to choice Doctor or press P to choice Patient").ToUpper();
                            if (choicePersonById == "D")
                            {
                                GetPersonById(_doctors);
                                break;
                            }
                            else if (choicePersonById == "P")
                            {
                                GetPersonById(_patients);
                                break;
                            }
                            break;
                        case "4":
                            var choiceAllPerson = GetInputFromUser("Show All Person - Press D to choice Doctor or press P to choice Patient").ToUpper();
                            if (choiceAllPerson == "D")
                            {
                                WriteAllPerson(_doctors);
                                break;
                            }
                            else if (choiceAllPerson == "P")
                            {
                                WriteAllPerson(_patients);
                                break;
                            }
                            break;
                        case "5":

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
                void AddDoctor()
                {
                    Console.WriteLine("Podaj imie pracownika:");
                    var name = Console.ReadLine()?.ToUpper();
                    Console.WriteLine("Podaj nazwisko pracownika:");
                    var surname = Console.ReadLine()?.ToUpper();
                    Console.WriteLine("Podaj pesel pracownika:");
                    var pesel = Console.ReadLine()?.ToUpper();
                    employeeRepository.Add(new Doctor { Name = name, SurName = surname, Pesel = pesel });
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
                T? GetPersonById<T>(IRepository<T> repository) where T : class, IPerson
                {
                    while (true)
                    {
                        var choiceId = GetInputFromUser($"Enter {typeof(T).Name} Id to find");
                        int IdValue;
                        var parsedId = int.TryParse(choiceId, out IdValue);
                        if (!parsedId)
                        {
                            WritelineColor("Enter the intiger ID", ConsoleColor.Magenta);
                        }
                        else
                        {
                            var person = repository.GetDataById(IdValue);
                            if (person != null)
                            {
                                WritelineColor(person.ToString()!, ConsoleColor.Green);
                            }
                            return person;
                        }
                    }
                }
                void RemovePerson<T>(IRepository<T> repository) where T : class, IPerson
                {
                    var idToRemove = GetPersonById(repository);
                    if (idToRemove != null)
                    {
                        while (true)
                        {
                            WritelineColor($"Do you really want to remove this {typeof(T).Name}?", ConsoleColor.Red);
                            var choice = GetInputFromUser("Press Y if YES\t\tPress N if NO").ToUpper();
                            if (choice == "Y")
                            {
                                repository.Remove(idToRemove);
                                break;
                            }
                            else if (choice == "N")
                            {
                                break;
                            }
                            else
                            {
                                WritelineColor("Please choose Yes or No:", ConsoleColor.Red);
                            }
                        }

                    }
                }
                void WriteAllPerson<T>(IRepository<T> repository) where T : class, IPerson
                {
                    WritelineColor($"-----All{typeof(T).Name}", ConsoleColor.Yellow);
                    var items = repository.GetAll();
                    foreach (var item in items)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
}
