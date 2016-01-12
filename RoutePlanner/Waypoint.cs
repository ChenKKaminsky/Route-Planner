using RoutePlanner.Entities.Interfaces;

namespace RoutePlanner.Entities
{
    public class Waypoint : IObjectWithState
    {
        public int Id { get; set; }

        public int ContactId { get; set; }

        public int AddressId { get; set; }

        public ObjectState ObjectState { get; set; }
    }
}