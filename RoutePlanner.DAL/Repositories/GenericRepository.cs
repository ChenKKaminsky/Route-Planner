using RoutePlanner.DAL.Interfaces;
using RoutePlanner.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using RoutePlanner.DAL.Contexts;
using System.Data.Entity;
using RoutePlanner.DAL.Helpers;

namespace RoutePlanner.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IObjectWithState
    {
        private bool _disposed = false;

        private IQueryable<T> _dbQuery;
        private RpDbContext _context;

        public GenericRepository() : this(new RpDbContext())
        {

        }

        public GenericRepository(RpDbContext context)
        {
            _context = context;
            _dbQuery = context.Set<T>();
        }

        public virtual IList<T> All(params Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> items = null;

            foreach (var property in navigationProperties)
            {
                _dbQuery = _dbQuery.Include(property);
            }
            items = _dbQuery.AsNoTracking().ToList();

            return items;
        }

        public virtual IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> items = null;

            foreach (var property in navigationProperties)
            {
                _dbQuery = _dbQuery.Include(property);
            }
            items = _dbQuery.AsNoTracking().Where(where).ToList();

            return items;
        }

        public virtual T GetSingle(Expression<Func<T, bool>> where)
        {
            T item = null;

            item = _dbQuery.AsNoTracking().FirstOrDefault(where);

            return item;
        }

        public virtual void InsertOrUpdate(params T[] items)
        {
            DbSet<T> dbSet = _dbQuery as DbSet<T>; 

            foreach (var item in items)
            {
                dbSet.Add(item);
                _context.ApplyStateChanges();
            }
        }

        public virtual void Remove(params T[] items)
        {
            InsertOrUpdate(items);
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                //release managed code
            }
            //release unmanaged code

            _disposed = true;
        }

        ~GenericRepository()
        {
            Dispose(false);
        }
    }
}
