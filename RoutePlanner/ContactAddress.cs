using RoutePlanner.Entities.Interfaces;
using System;

namespace RoutePlanner.Entities
{
    public class ContactAddress : IObjectWithState
    {
        public int Id { get; set; }

        public virtual Address Address { get; set; }
        public int AddressId { get; set; }

        public virtual Contact Contact { get; set; }
        public int ContactId { get; set; }

        public ObjectState ObjectState { get; set; }
    }
}