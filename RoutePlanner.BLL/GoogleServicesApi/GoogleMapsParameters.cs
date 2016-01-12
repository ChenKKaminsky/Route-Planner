using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.Google
{
    public class GoogleMapsParameters
    {
        public string Language { get; set; }

        //metric / imperial
        public string Units { get; set; }

        //This key identifies the application for purposes of quota management.
        public string Key { get; set; }

        public GoogleMapsParameters(string key = "AIzaSyCL-rRjhuNtKrKuP9oXxw63lpatNHuzL3E", string units = "metric", string language = "en-gb")
        {
            Key = key;
            Units = units;
            Language = language;
        }

        public string GetParametersString()
        {
            var nvc = new Dictionary<string, string>();

            var properties = GetType().GetProperties();

            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(this);

                if (propValue is IEnumerable && !(propValue is string))
                {
                    if ((propValue as ICollection).Count > 0)
                    {
                        var multiValuesProperty = new StringBuilder();
                        foreach (var value in propValue as IEnumerable)
                        {
                            var trimedVaule = value.ToString().Replace(" ", "");
                            multiValuesProperty.Append(trimedVaule);
                            multiValuesProperty.Append("|");
                        }
                        multiValuesProperty.Remove(multiValuesProperty.Length - 1, 1);

                        nvc.Add(prop.Name, multiValuesProperty.ToString());
                    }
                }
                else if (propValue != null)
                    nvc.Add(prop.Name, propValue.ToString());
            }
            return nvc.ToQueryString();
        }
    }
}
