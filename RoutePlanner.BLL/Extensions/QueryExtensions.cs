using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace RoutePlanner.Google
{
    public static class QueryExtensions
    {
        public static string ToQueryString(this Dictionary<string, string> dict)
        {
            IEnumerable<string> segments = from key in dict.Keys
                                           select string.Format("{0}={1}", key.ToLower(), dict[key].Replace(" ",""));
            return string.Join("&", segments);
        }
    }
}
