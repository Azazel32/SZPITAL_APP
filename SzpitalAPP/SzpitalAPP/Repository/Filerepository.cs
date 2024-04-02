using System.Text.Json;
using System.Text.Json.Nodes;
using SzpitalAPP.Person;

namespace SzpitalAPP.Repository
{
    public class Filerepository<T> : IRepository<T> where T : class, IPerson
    {
        const string LogFilePath = "Log.txt";
        private readonly string file;
        private List<T> items = new List<T>();
        public EventHandler<T> ItemAdded;
        public EventHandler<T> ItemRemoved;

        public Filerepository(string FileName)
        {
            file = FileName;
            GetData();
            this.ItemAdded += EventItemAdded;
            this.ItemRemoved += EventItemRemoved;
        }
        void EventItemAdded(object? sender, T item)
        {
            using (StreamWriter sw = File.AppendText(LogFilePath))
            {
                sw.WriteLine($"{DateTime.Now} - Added {item.ToString}");
            }
        }

        void EventItemRemoved(object? sender, T item)
        {
            using (StreamWriter sw = File.AppendText(LogFilePath))
            {
                sw.WriteLine($"{DateTime.Now} - Removed {item.ToString}");

            }
        }
        public void GetData()
        {
            if (File.Exists(file))
            {
                using (var reader = new StreamReader(file))
                {
                    var line = reader.ReadLine();
                    items = JsonSerializer.Deserialize<List<T>>(line) ?? new List<T>();
                }
            }
        }
        public void Save()
        {
            if (File.Exists(file))
            {
                using (var writer = new StreamWriter(file))
                {
                    var json = JsonSerializer.Serialize(items);
                    writer.WriteLine(json);
                }
            }
        }

        public void Add(T item)
        {
            items.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public IEnumerable<T> GetAll()
        {
            return items;
        }

        public T GetById(int id)
        {
            return items[id];
        }

        public void Remove(T item)
        {
            items.Remove(item);
            ItemRemoved?.Invoke(this, item);
        }
    }

}
