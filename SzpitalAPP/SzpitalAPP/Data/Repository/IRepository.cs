﻿
using SzpitalAPP.Person;

namespace SzpitalAPP.Repository
{
    public interface IRepository<T> : IWriteRepository<T>,IReadRepository<T> where T:class,IPerson
    {
        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemoved;
    }
}
