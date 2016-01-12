using RoutePlanner.BLL.Interfaces;
using RoutePlanner.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.BLL
{
    public class RoutePlannerService : IRoutePlannerService
    {
        private IAddressesRepository _addressesRepo;
        private ICarPlanner _carPlanner;
        private IObjectMapper<RouteInternal, Route> _mapper;
        private IRoutePlanner _routePlanner;
        private IGoogleMapsEmbedUrlProvider _urlProvider;

        public RoutePlannerService(ICarPlanner carPlanner, IRoutePlanner routePlanner, 
            IAddressesRepository addressesRepo, IGoogleMapsEmbedUrlProvider urlProvider, 
            IObjectMapper<RouteInternal, Route> mapper)
        {
            _routePlanner = routePlanner;
            _addressesRepo = addressesRepo;
            _urlProvider = urlProvider;
            _carPlanner = carPlanner;
            _mapper = mapper;
        }


        public RoutePlan GetRoutePlan(IEnumerable<int> addressesIds, int destinationId)
        {
            //Get Account Settings
            var carPlan = _carPlanner.GetCarPlan(new CarPlanParameters()
                                                    {
                                                        PickupCount = addressesIds.Count(),
                                                        MaxCarCapacity = 3,
                                                        MinCarCapacity = 2
                                                    });

            var internalRoutePlan = _routePlanner.GetRoutePlan(addressesIds,destinationId, carPlan);

            RoutePlan plan = new RoutePlan();
            Route route;
            foreach (var iroute in internalRoutePlan.Routes)
            {
                route = _mapper.Map(iroute.Route);
                plan.Routes.Add(new RouteDetails()
                {
                    Route = route,
                    Url = _urlProvider.GetRouteUrl(route)
                });
            }

            return plan;

        }
    }
}
