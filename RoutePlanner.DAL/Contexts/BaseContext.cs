using System;
using System.Data.Entity;

namespace RoutePlanner.DAL.Contexts
{
    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<TContext>(new DropCreateDatabaseAlways<TContext>());
        }
        protected BaseContext() : base("name=Default")
        {

        }
    }
}