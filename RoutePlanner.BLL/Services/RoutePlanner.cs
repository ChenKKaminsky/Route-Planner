using Facet.Combinatorics;
using RoutePlanner.BLL.Interfaces;
using RoutePlanner.DAL.Interfaces;
using RoutePlanner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.BLL
{
    public class RoutePlanner : IRoutePlanner
    {
        private IMatrixEntriesRepository _matrixRepository;

        public RoutePlanner(IMatrixEntriesRepository matrixRepository)
        {
            _matrixRepository = matrixRepository;
        }

        public RoutePlanInternal GetRoutePlan(IEnumerable<int> addressesIds, int destinationId, IEnumerable<int> carPlan)
        {
            RoutePlanInternal routePlan = new RoutePlanInternal();

            var routes = new List<RouteInternal>();

            foreach (var car in carPlan)
            {
                var matrixByDescendingDistanceFromDestination = _matrixRepository
                                                                .GetList(a => a.DestinationId == destinationId
                                                                        && addressesIds.Contains(a.OriginId))
                                                                .OrderByDescending(info => info.Value)
                                                                .ToList();


                var optimalVariation = GetOptimizedPickupVariation(matrixByDescendingDistanceFromDestination, destinationId, car);

                routes.Add(optimalVariation);

                //Remove before iteration
                matrixByDescendingDistanceFromDestination
                    .RemoveAll(ai => optimalVariation.Legs.Select(leg => leg.StartAddressId).Contains(ai.OriginId));
            }

            return routePlan;
        }

        private RouteInternal GetOptimizedPickupVariation
                 (IEnumerable<MatrixEntry> matrixDescendingDistanceFromDestination, int destinationId, int carCapacity)
        {
            //origin as the farest point from destination
            var originId = matrixDescendingDistanceFromDestination.First().OriginId;

            //selecting only ids from an ordered list of addresses to be used as feed to variations service
            var variationInput = matrixDescendingDistanceFromDestination.Select(a => a.OriginId).ToList();

            //must include all selected addresses to be able to pick to optimal variation
            Variations<int> variations = new Variations<int>(variationInput, carCapacity);

            //selecting only variations contains the origin address
            //the first seat plan had chance to have less pickups - thus, it is the best to include the farest point 
            var variationsIncludesOriginOnly = variations
                .Where(c => c.Contains(originId)).ToList();

            var alternatives = new List<RouteInternal>();

            foreach (var variation in variationsIncludesOriginOnly)
            {
                var variationResults = new RouteInternal();

                variationResults.Duration = 0;
                variationResults.PickupCount = carCapacity;

                for (int i = 0; i < variation.Count() - 1; i++)
                {
                    var leg = new LegInternal()
                    {
                        StartAddressId = variation[i],
                        EndAddressId = variation[i + 1],
                    };

                    leg.LegDuration = matrixDescendingDistanceFromDestination
                    .FirstOrDefault(mc => mc.OriginId == leg.StartAddressId
                                    && mc.DestinationId == leg.EndAddressId)
                                    .Value;

                    variationResults.Legs.Add(leg);
                    variationResults.Duration += leg.LegDuration;
                }

                //Add duration from end point of combo to destination
                var variationEndToDestination = matrixDescendingDistanceFromDestination
                    .First(a => a.OriginId == variation.Last());

                var legToDestination = new LegInternal()
                {
                    StartAddressId = variationEndToDestination.OriginId,
                    //EF circular cascade delete constraint forced to define this as nullable 
                    EndAddressId = variationEndToDestination.DestinationId,
                    LegDuration = variationEndToDestination.Value
                };

                variationResults.Legs.Add(legToDestination);
                variationResults.Duration += legToDestination.LegDuration;

                alternatives.Add(variationResults);
            }

            var optimalVariation = alternatives
                .First(o => o.Duration == alternatives.Min(op => op.Duration));

            optimalVariation.DestinationId = destinationId;
            return optimalVariation;
        }
    }
}
