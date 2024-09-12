using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using SzpitalAPP.Components.CSVReader;
using SzpitalAPP.Data;
using SzpitalAPP.Data.Person;
using SzpitalAPP.Person;
namespace SzpitalAPP.Repository
{
    public class SqlRepository<T> : IRepository<T> where T : class, IPerson, new()
    {
        private readonly DbSet<T> _dbSet;
        private readonly SzpitalDbContext _szpitalDbContext;
        

        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemoved;
        public SqlRepository(SzpitalDbContext dbContext)
        {
           
            _szpitalDbContext = dbContext;
            _dbSet = _szpitalDbContext.Set<T>();
            _szpitalDbContext.Database.EnsureCreated();
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
            _szpitalDbContext.SaveChanges();
            ItemAdded?.Invoke(this, item);
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
            _szpitalDbContext?.SaveChanges();
            ItemRemoved?.Invoke(this, item);
        }
        public void Save()
        {
            _szpitalDbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }

        public IEnumerable<T> Read()
        {
            return _dbSet.ToList();
        }

        public int CountList()
        {
            return Read().ToList().Count;
        }

        public T GetDataById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Update(T item) 
        {
            _dbSet.Update(item);
            _szpitalDbContext.SaveChanges();
        }
        
    }
}
