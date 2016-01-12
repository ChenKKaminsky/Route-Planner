using System;
using RoutePlanner.Entities.Interfaces;

namespace RoutePlanner.Entities
{
    public class AuthorizationLevel : IObjectWithState
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public ObjectState ObjectState { get; set; }
    }
}