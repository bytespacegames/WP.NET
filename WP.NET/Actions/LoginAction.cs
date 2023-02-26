using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WP.NET.Actions
{
    public class LoginAction
    {
        public static HTTPAction Login(string username, string password, string loginToken)
        {
            var parameters = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("action", "login"),
                new KeyValuePair<string, string>("lgname", username),
                new KeyValuePair<string, string>("lgpassword", password),
                new KeyValuePair<string, string>("lgtoken", loginToken),
                new KeyValuePair<string, string>("format", "json"),
                new KeyValuePair<string, string>("formatversion", "2"),
            });

            return new HTTPAction(parameters);
        }
    }
}
