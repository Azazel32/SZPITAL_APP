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
        private readonly HospitalDbContext _hospitalDbContext;
        

        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemoved;
        public SqlRepository(HospitalDbContext dbContext)
        {

            _hospitalDbContext = dbContext;
            _dbSet = _hospitalDbContext.Set<T>();
            _hospitalDbContext.Database.EnsureCreated();
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
            _hospitalDbContext.SaveChanges();
            ItemAdded?.Invoke(this, item);
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
            _hospitalDbContext?.SaveChanges();
            ItemRemoved?.Invoke(this, item);
        }
        public void Save()
        {
            _hospitalDbContext.SaveChanges();
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
            _hospitalDbContext.SaveChanges();
        }
        
    }
}
