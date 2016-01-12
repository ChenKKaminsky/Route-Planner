using System;
using System.Threading.Tasks;
using System.Net.Http;
using RoutePlanner.Services;

namespace RoutePlanner.Google
{
    public abstract class GoogleMapsApi
    {
        //Export to config file ?
        /// <summary>
        /// {0} - Host
        /// {1}- Name
        /// {2} - output
        /// {3} - parameters
        /// </summary>
        public string ServiceName { get; set; }

        public string Host { get; set; }

        public string Output { get; set; }

        public GoogleMapsApi(string serviceName, string host = "https://maps.googleapis.com/maps/api" , string output = "json")
        {
            ServiceName = serviceName.ToLower().Replace(" ", "");
            Output = output;
            Host = host;
        }

        public async Task<ServiceResponse<string>> GetResponseAsync(GoogleMapsParameters parameters)
        {
            var result = new ServiceResponse<string>()
            {
                Success = false,
                Message = "Failed to get a response from service"
            };

            var uri = GetUri(parameters);

            using (var client = new HttpClient())
            {
                try
                {
                    result.Value = await client.GetStringAsync(uri);
                    result.Success = true;
                    result.Message = "Ok";
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        protected Uri GetUri(GoogleMapsParameters parameters)
        {
            var uri = new Uri($"{Host}/{ServiceName}/{Output}?{parameters.GetParametersString()}");
            return uri;
        }
    }


}
