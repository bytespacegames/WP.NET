using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WP.NET.Actions
{
    public class TokenAction
    {
        public static HTTPAction Token(string requestType)
        {
            var parameters = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("action", "query"),
                new KeyValuePair<string, string>("meta", "tokens"),
                new KeyValuePair<string, string>("type", requestType),
                new KeyValuePair<string, string>("format", "json"),
                new KeyValuePair<string, string>("formatversion", "2"),
            });
            return new HTTPAction(parameters);
        }
    }
}
