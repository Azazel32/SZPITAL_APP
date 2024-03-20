
namespace SzpitalAPP.Repository
{
    public interface IReadRepository<out T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
