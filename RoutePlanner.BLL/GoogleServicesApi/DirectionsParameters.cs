using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.Google
{
    public class DirectionsParameters : GoogleMapsParameters
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public List<string> Waypoints { get; set; }

        public DirectionsParameters(bool oprimizeRout = true)
        {
            Optimize = oprimizeRout;
            Waypoints = new List<string>();
            Waypoints.Add("optimize:" + Optimize);
        }

        //Must not be a property otherwise get to be part of the URI global parameter list
        private bool Optimize;
    }
}
