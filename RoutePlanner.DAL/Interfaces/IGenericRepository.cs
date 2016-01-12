using RoutePlanner.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RoutePlanner.DAL.Interfaces
{
    public interface IGenericRepository<T> : IDisposable where T : class , IObjectWithState
    {
        IList<T> All(params Expression<Func<T, object>>[] navigationProperties);

        IList<T> GetList(Expression<Func<T,bool>> where ,params Expression<Func<T, object>>[] navigationProperties);

        T GetSingle(Expression<Func<T, bool>> where);

        void InsertOrUpdate(params T[] items);

        void Remove(params T[] items);

        void SaveChanges();
    }
}
