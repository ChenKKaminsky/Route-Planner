using RoutePlanner.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace RoutePlanner.Entities
{
    public class Order : IObjectWithState , IDentityProtected
    {
        public int Id { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DueDate { get; set; }

        public virtual ICollection<Route> Routes { get; set; }

        public ObjectState ObjectState { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}