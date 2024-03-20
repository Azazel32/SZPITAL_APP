
using SzpitalAPP.Person;

namespace SzpitalAPP.Repository
{
    public interface IRepository<T> : IWriteRepository<T>,IReadRepository<T> where T:IPerson
    {

    }
}
