using RoutePlanner.Entities;
using System.Collections.Generic;

namespace RoutePlanner.BLL
{
    public class RoutePlan
    {
        public IList<RouteDetails> Routes { get; set; }
    }

    public class RoutePlanInternal
    {
        public IList<RouteDetailsInternal> Routes { get; set; }
    }

    public class RouteDetails
    {
        public Route Route { get; set; }
        public string Url { get; set; }
    }

    public class RouteDetailsInternal
    {
        public RouteInternal Route { get; set; }
        public string Url { get; set; }
    }

    public class Route
    {
        public int PickupCount { get; set; }

        public int Duration { get; set; }

        public IList<Leg> Legs { get; set; }

        public Address Destination { get; set; }

        public Route()
        {
            Legs = new List<Leg>();
        }
    }

    public class Leg
    {
        public int LegDuration { get; set; }

        public Contact StartContact { get; set; }
    }

    public class RouteInternal
    {
        public int PickupCount { get; set; }

        public int Duration { get; set; }

        public IList<LegInternal> Legs { get; set; }

        public int DestinationId { get; set; }

        public RouteInternal()
        {
            Legs = new List<LegInternal>();
        }
    }

    public class LegInternal
    {
        public int LegDuration { get; set; }

        public int StartAddressId { get; set; }

        public int EndAddressId { get; set; }
    }

}