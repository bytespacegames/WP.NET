using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WP.NET.Actions
{
    public class PageIDQueryAction
    {
        public static HTTPAction Query(string pageTitle)
        {
            var parameters = new FormUrlEncodedContent(new[]
            {
                 new KeyValuePair<string, string>("action", "query"),
                 new KeyValuePair<string, string>("titles", pageTitle),
                 new KeyValuePair<string, string>("prop", "info"),
                 new KeyValuePair<string, string>("rvslots", "*"),
                 new KeyValuePair<string, string>("format", "json"),
                 new KeyValuePair<string, string>("formatversion", "2")
            });
            return new HTTPAction(parameters);
        }
    }
}
