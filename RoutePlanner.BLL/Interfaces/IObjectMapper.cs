using RoutePlanner.DAL.Interfaces;
using RoutePlanner.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.BLL.Interfaces
{
    public interface IObjectMapper<TIn, TOut>
    {
        TOut Map(TIn obj);
    }

    public class ObjectMapper<TIn, TOut> : IObjectMapper<TIn, TOut>
        where TIn : class, IObjectWithState
        where TOut : class, IObjectWithState , new()
    {
        private IGenericRepository<TIn> _repo;

        public ObjectMapper(IGenericRepository<TIn> repo)
        {
            _repo = repo;
        }

        public TOut Map(TIn obj)
        {
            var origin = typeof(TIn);
            var target = typeof(TOut);

            var result = new TOut();

            foreach (var prop in origin.GetProperties())
            {
                if (prop.Name.ToLower().Contains("id"))
                {
                    var tprop = target.GetProperties().FirstOrDefault(p => p.Name.ToLower().Contains(prop.Name.ToLower().Replace("id", "")));

                    tprop.SetValue(result, _repo.GetSingle(i => (int)i.GetType().GetProperty(prop.Name).GetValue(i) == (int)prop.GetValue(obj)));
                }
            }
            return result;
        }
    }
}
