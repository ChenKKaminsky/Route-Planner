using System.Collections.Generic;

namespace RoutePlanner.Google
{
    public class DistanceMatrixParameters : GoogleMapsParameters
    {
        public DistanceMatrixParameters()
        {
            Origins = new List<string>();
            Destinations = new List<string>();
        }

        public ICollection<string> Origins { get; set; }
        public ICollection<string> Destinations { get; set; }
    }
}
