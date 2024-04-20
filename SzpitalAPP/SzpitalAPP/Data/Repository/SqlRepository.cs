using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using SzpitalAPP.Person;
namespace SzpitalAPP.Repository
{
    public class SqlRepository<T> : IRepository<T> where T : class, IPerson, new()
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
        public void Add(T item)
        {
            _dbSet.Add(item);
            _dbContext.SaveChanges();
            ItemAdded?.Invoke(this, item);
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
            _dbContext?.SaveChanges();
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
    }
}
