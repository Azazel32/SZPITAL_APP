using System.Runtime.CompilerServices;
using SzpitalAPP.Person;

namespace SzpitalAPP.Repository.Extensions
{
    public static class Extension
    {
        public static void AddBatch<T>(this IRepository<T> repository,IEnumerable<T> items)
            where T :class, IPerson
        {
            foreach(var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }
    }
}
