using RoutePlanner.BLL.Interfaces;
using System.Collections.Generic;

namespace RoutePlanner.BLL
{
    public class CarPlaner : ICarPlanner
    {
        public IEnumerable<int> GetCarPlan(CarPlanParameters carPlanParams)
        {
            List<int> result = new List<int>();

            if (carPlanParams.PickupCount < carPlanParams.MinCarCapacity)
            {
                result.Add(carPlanParams.PickupCount);
                return result;
            }
            else
            {
                //Calculate number of cars: Ex. 9 / 4 = 2
                int nCars = carPlanParams.PickupCount / carPlanParams.MaxCarCapacity;

                //Get reminder: Ex. 9 % 4 = 1
                var reminder = carPlanParams.PickupCount % carPlanParams.MaxCarCapacity;

                //Add results: Ex. { 4 , 4 } with 1 pickup left behind
                for (int i = 0; i < nCars; i++)
                {
                    result.Add(carPlanParams.MaxCarCapacity);
                }

                if (reminder != 0)
                {
                    //Respect minCarCapacity constraint - additional car must have n pickups >= to minCarCapacity
                    //          1       <       2       ?       2       :       1
                    //reminder = reminder < minCarCapacity ? minCarCapacity : reminder;

                    if (reminder < carPlanParams.MinCarCapacity)
                    {
                        var additionalCarSeats = carPlanParams.MinCarCapacity;

                        //add new car 
                        result.Insert(0, additionalCarSeats);

                        //update and balance the seates moved from the full car to the newly added car
                        result[1] -= (carPlanParams.MinCarCapacity - reminder);
                    }
                    else
                    {
                        result.Add(reminder);
                    }
                }
            }
            return result;

        }

    }
}
