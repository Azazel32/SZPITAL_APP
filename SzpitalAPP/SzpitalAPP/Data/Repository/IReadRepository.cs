
namespace SzpitalAPP.Repository
{
    public interface IReadRepository<out T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Read();
        int CountList();
        T GetDataById(int id);

    }
}
