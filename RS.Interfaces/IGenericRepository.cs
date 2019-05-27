using System;
using System.Collections.Generic;

namespace RS.Interfaces
{
    public interface IGenericRepository<T> : IDisposable
    {
        IEnumerable<T> GetList();
        T Get(long id);
        void Create(T item);
        void Update(T item);
        void Delete(long id);
        void Save();
    }
}
