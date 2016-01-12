using RoutePlanner.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RoutePlanner.DAL.Interfaces
{
    public interface ISecuredGenericRepository<T> : IDisposable where T : class , IObjectWithState , IDentityProtected
    {
        IList<T> All(int id , params Expression<Func<T, object>>[] navigationProperties);

        IList<T> GetList(int id, Expression<Func<T,bool>> where ,params Expression<Func<T, object>>[] navigationProperties);

        T GetSingle(int id, Expression<Func<T, bool>> where);

        void InsertOrUpdate(int id, params T[] items);

        void Remove(int id, params T[] items);

        void SaveChanges();
    }
}
