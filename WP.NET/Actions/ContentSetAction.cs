using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WP.NET.Actions
{
    public class ContentSetAction
    {
        public static async Task<HTTPAction> SetContent(string pageTitle, string content)
        {
            string csrf = await StaticManager.bot.GetCSRF();
            var parameters = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("action", "edit"),
                new KeyValuePair<string, string>("title", pageTitle),
                new KeyValuePair<string, string>("text", content),
                new KeyValuePair<string, string>("summary", "Changed page source."),
                new KeyValuePair<string, string>("format", "json"),
                new KeyValuePair<string, string>("formatversion", "2"),
                new KeyValuePair<string, string>("bot", "1"),
                new KeyValuePair<string, string>("token", csrf),
            });

            return new HTTPAction(parameters);
        }
    }
}
