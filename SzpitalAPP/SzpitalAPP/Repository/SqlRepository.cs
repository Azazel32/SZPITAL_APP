using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using SzpitalAPP.Person;
namespace SzpitalAPP.Repository
{
    public class SqlRepository<T> : IRepository<T> where T:class,IPerson,new()
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;

        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemoved;
        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public T? GetByData(string name,string surname)
        {
            return _dbSet.Find(name, surname);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
            ItemRemoved?.Invoke(this, item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }

        public void SaveDataToFile<T>(string filePath, SqlRepository<T> repository) where T : class, IPerson, new()
        {
            var items = JsonSerializer.Serialize<List<T>>(repository.GetAll().ToList());

            File.WriteAllText(filePath, items);

            Console.WriteLine($"Zapisano:{items}");

            foreach (var item in repository.GetAll())
            {
                Console.WriteLine(item);
            }
        }
        public void GetDataFromFile<T>(string filePath, SqlRepository<T> repository) where T : class, IPerson, new()
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
    }
}
