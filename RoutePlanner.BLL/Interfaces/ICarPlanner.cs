using System.Collections.Generic;

namespace RoutePlanner.BLL.Interfaces
{
    public interface ICarPlanner
    {
        /// <summary>
        /// Returns collection of integers that represent the number of pickups / seats to be used in a car
        /// This is being used by the route planner to populate these seats plan and produca a complete and optimized routes plan
        /// </summary>
        /// <param name="carPlanParams"></param>
        /// <returns></returns>
        IEnumerable<int> GetCarPlan(CarPlanParameters carPlanParams);
    }
}
