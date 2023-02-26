using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WP.NET.Actions
{
    public class ContentGetAction
    {
        public static HTTPAction Content(string pageTitle)
        {
            var parameters = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("action", "query"),
                new KeyValuePair<string, string>("prop", "extracts"),
                new KeyValuePair<string, string>("titles", pageTitle),
                new KeyValuePair<string, string>("prop", "revisions"),
                new KeyValuePair<string, string>("rvprop", "content"),
                new KeyValuePair<string, string>("rvslots", "main"),
                new KeyValuePair<string, string>("format", "json"),
                new KeyValuePair<string, string>("formatversion", "2"),
            });
            return new HTTPAction(parameters);
        }
    }
}
