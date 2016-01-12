using RoutePlanner.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.BLL.Interfaces
{
    public interface IGoogleMapsEmbedUrlProvider
    {
        string GetRouteUrl(Route route);
    }
}
