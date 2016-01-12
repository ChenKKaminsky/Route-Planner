using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using RoutePlanner.Services;

namespace RoutePlanner.Google
{
    public class DistanceMatrixApi : GoogleMapsApi
    {
        public DistanceMatrixApi()
            : base("distance matrix")
        {
        }

        public async Task<ServiceResponse<int>> GetAddressInfoAsync(DistanceMatrixParameters parameters, InfoType info)
        {
            var result = new ServiceResponse<int>()
            {
                Success = false,
                Message = "Failed to get Buration data from service"
            };

            var response = await GetResponseAsync(parameters);

            if (response.Success)
            {
                var json = JsonConvert.DeserializeObject<DistanceMatrixResponse>(response.Value);

                var elem = json.Rows[0].Elements[0];

                var propName = Enum.GetName(typeof(InfoType), (int)info);

                var item = elem.GetType().GetProperty(propName).GetValue(elem);

                var value = item.GetType().GetProperty("Value").GetValue(item);

                result.Value = (int)value;
                result.Success = true;
                result.Message = "";
            }
            else
            {
                throw new Exception(response.Message, new Exception(response.Value));
            }

            return result;
        }

        //public async Task<ServiceResponse<IEnumerable<AddressRelativeInfo>>>
        //    UpdateAddressesRelativeInfoAsync(Address newAddress, IEnumerable<Address> existingAddresses, InfoType info)
        //{
        //    var response = new ServiceResponse<IEnumerable<AddressRelativeInfo>>()
        //    {
        //        Success = false,
        //        Message = "Failed to retrieve addresses relative info from service"
        //    };

        //    var result = new List<AddressRelativeInfo>();

        //    foreach (var existing in existingAddresses)
        //    {
        //        var pairs = new List<Tuple<Address, Address>> {
        //            new Tuple<Address, Address> ( newAddress, existing ),
        //            new Tuple<Address, Address> ( existing, newAddress )
        //        };

        //        foreach(var pair in pairs)
        //        {
        //            var origin = pair.Item1;
        //            var destination = pair.Item2;

        //            var parameters = new DistanceMatrixParameters()
        //            {
        //                Units = "metric",
        //                Language = "en-gb",
        //                Origins = new string[] { origin.ToString() },
        //                Destinations = new string[] {destination.ToString() }
        //            };

        //            //Google limit is no more than 10 queries per 10 seconds
        //            await Task.Delay(10000 / 100);

        //            var gResponse = await GetAddressInfoAsync(parameters, info);

        //            if (gResponse.Success)
        //            {
        //                result.Add(new AddressRelativeInfo()
        //                {
        //                    OriginAddressId = origin.Id,
        //                    DestinationAddressId = destination.Id,
        //                    Value = gResponse.Value
        //                });
        //            }
        //            else
        //            {
        //                return response;
        //            } 
        //        }
        //    }

        //    response.Value = result;
        //    response.Success = true;
        //    response.Message = "Success";

        //    return response;
        //}
    }

    public enum InfoType
    {
        Duration,
        Distance
    }
}
