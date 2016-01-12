using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.BLL.Interfaces
{
    public interface IRoutePlanner
    {
        RoutePlanInternal GetRoutePlan(IEnumerable<int> addressesIds, int destinationId, IEnumerable<int> carPlan);
    }
}
