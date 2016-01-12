using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.BLL
{
    public interface IRoutePlannerService
    {
        RoutePlan GetRoutePlan(IEnumerable<int> addressesIds, int destinationId);
    }
}
