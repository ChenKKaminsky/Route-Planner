using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.Google
{
    public class EmbedAPI : GoogleMapsApi
    {
        public EmbedAPI()
            : base("embed/v1", host: "https://www.google.com/maps", output: "directions")
        {

        }
        public Uri GetUri(DirectionsParameters parameters)
        {
            return base.GetUri(parameters);
        }
        //https://www.google.com/maps/embed/v1/directions?

    }
}
