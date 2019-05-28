using RS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.DAL
{
    public class Repository<T> : IGenericRepository<T> where T : class
    {
        private bool disposed = false;

        private RSContext db;
        DbSet<T> dbSet;

        public Repository(RSContext db)
        {
            this.db = db;
            dbSet = db.Set<T>();
        }

        public void Create(T item)
        {
            dbSet.Add(Cart);
        }

        public void Delete(long id)
        {
            T item = dbSet.Find(id);
            if (item != null)
                dbSet.Remove(item);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T Get(long id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetList()
        {
            return dbSet.AsNoTracking();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T item)
        {
            db.Entry(Cart).State = EntityState.Modified;
        }
    }
}
