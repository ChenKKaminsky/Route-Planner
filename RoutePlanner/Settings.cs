using RoutePlanner.Entities.Interfaces;

namespace RoutePlanner.Entities
{
    public class Settings : IObjectWithState
    {
        public int Id { get; set; }

        public int MinPickupsPerCar { get; set; }

        public int MaxPickupsPerCar { get; set; }

        public int MaxTripDuration { get; set; }

        public ObjectState ObjectState { get; set; }

    }
}