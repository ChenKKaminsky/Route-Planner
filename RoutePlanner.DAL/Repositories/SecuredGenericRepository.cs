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
    class SecuredGenericRepository<T> : ISecuredGenericRepository<T> where T : class, IObjectWithState, IDentityProtected
    {
        private bool _disposed = false;

        private IQueryable<T> _dbQuery;
        private RpDbContext _context;

        public SecuredGenericRepository() : this(new RpDbContext())
        {

        }

        public SecuredGenericRepository(RpDbContext context)
        {
            _context = context;
            _dbQuery = context.Set<T>();
        }


        public IList<T> All(int id, params Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> items = null;

            foreach (var property in navigationProperties)
            {
                _dbQuery = _dbQuery.Include(property);
            }
            items = _dbQuery
                .AsNoTracking()
                .Where(e => e.AccountId == id)
                .ToList();

            return items;
        }

        public IList<T> GetList(int id, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> items = null;

            foreach (var property in navigationProperties)
            {
                _dbQuery = _dbQuery.Include(property);
            }
            items = _dbQuery
                .AsNoTracking()
                .Where(e => e.AccountId == id)
                .Where(where)
                .ToList();

            return items;
        }

        public T GetSingle(int id, Expression<Func<T, bool>> where)
        {
            T item = null;

            item = _dbQuery
                .AsNoTracking()
                .Where(e => e.AccountId == id)
                .FirstOrDefault(where);

            return item;
        }

        public void InsertOrUpdate(int id, params T[] items)
        {
            DbSet<T> dbSet = _dbQuery as DbSet<T>;

            foreach (var item in items)
            {
                if(item.ObjectState == ObjectState.Added) item.AccountId = id;

                dbSet.Add(item);
                _context.ApplyStateChanges();
            }
        }

        public void Remove(int id, params T[] items)
        {
            InsertOrUpdate(id, items);
        }

        public void SaveChanges()
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

        ~SecuredGenericRepository()
        {
            Dispose(false);
        }
    }
}
