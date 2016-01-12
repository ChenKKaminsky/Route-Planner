using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.Google
{
    public class DirectionsAPI : GoogleMapsApi
    {
        public DirectionsAPI() : base ("directions"){}
    }
}
