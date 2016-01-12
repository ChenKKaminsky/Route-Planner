using RoutePlanner.Entities.Interfaces;
using System.Collections.Generic;

namespace RoutePlanner.Entities
{
    public class Route : IObjectWithState
    {
        public int Id { get; set; }

        public bool IsDropoff { get; set; }

        public int DestinationId { get; set; }

        public virtual ICollection<Waypoint> Waypoints { get; set; }

        public ObjectState ObjectState { get; set; }
    }
}