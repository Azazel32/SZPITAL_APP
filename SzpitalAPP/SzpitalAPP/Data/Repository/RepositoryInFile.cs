using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using SzpitalAPP.Person;

namespace SzpitalAPP.Repository
{
    public class RepositoryInFile<T> : IRepository<T> where T : class, IPerson
    {
        const string LogFilePath = "Log.txt";
        private readonly string file = $"{typeof(T).Name}Repository.json";
        private readonly List<T> _items = new List<T>();
        private int lastUsedId = 1;
        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemoved;


        public RepositoryInFile()
        {

            
            this.ItemAdded += EventItemAdded;
            this.ItemRemoved += EventItemRemoved;
        }
        public void Update(T item)
        {
            this._items.Add(item);
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

        public void Save()
        {
            File.Delete(file);
            var objectsSerialized = JsonSerializer.Serialize<IEnumerable<T>>(_items);
            File.WriteAllText(file, objectsSerialized);
        }

        public void Add(T item)
        {
            if (_items.Count == 0)
            {
                item.Id = lastUsedId;
                lastUsedId++;
            }
            else if (_items.Count > 0)
            {
                lastUsedId = _items[_items.Count - 1].Id;
                item.Id = ++lastUsedId;
            }
            _items.Add(item);
            ItemAdded?.Invoke(this, item);
        }
        public T? GetDataById(int id)
        {
            var itemById = _items.SingleOrDefault(x => x.Id == id);
            if (itemById == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Object {typeof(T).Name} with id {id} not found.");
                Console.ResetColor();
            }
            return itemById;
        }
        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }
        public void Remove(T item)
        {
            _items.Remove(item);
            ItemRemoved?.Invoke(this, item);
        }
        public IEnumerable<T> Read()
        {
            if (File.Exists(file))
            {
                var objectsSerialized = File.ReadAllText(file);
                if (objectsSerialized != "")
                {
                    var deserializedObjects = JsonSerializer.Deserialize<IEnumerable<T>>(objectsSerialized);
                    if (deserializedObjects != null)
                    {
                        foreach (var item in deserializedObjects)
                        {
                            _items.Add(item);
                        }
                    }
                }
            }
            return _items;
        }
        public int CountList()
        {
            return _items.Count;
        }
    }

}
