﻿using RoutePlanner.Entities;
using RoutePlanner.Entities.Interfaces;
using System;
using System.Data.Entity;

namespace RoutePlanner.DAL.Helpers
{
    public class StateHelper
    {
        public static EntityState ConvertState(ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Added:
                    return EntityState.Added;
                case ObjectState.Modified:
                    return EntityState.Modified;
                case ObjectState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }
    }
}