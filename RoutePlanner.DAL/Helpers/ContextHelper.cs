
using RoutePlanner.Entities;
using RoutePlanner.Entities.Interfaces;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace RoutePlanner.DAL.Helpers
{
    public static class ContextHelper
    {
        public static void ApplyStateChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<IObjectWithState>())
            {
                IObjectWithState stateInfo = entry.Entity;
                entry.State = StateHelper.ConvertState(stateInfo.ObjectState);
            }
        }

        //public static void DisplayState(this DbContext context,  logger)
        //{
        //    context.ChangeTracker.Entries().ToList()
        //        .ForEach(e => logger.LogError($"{e.Entity.GetType()} : {e.State}"));
        //}
    }
}

