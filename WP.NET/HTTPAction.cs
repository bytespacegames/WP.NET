using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WP.NET
{
    public class HTTPAction
    {
        FormUrlEncodedContent parameters;
        public HTTPAction(FormUrlEncodedContent parameters)
        {
            this.parameters = parameters;
        }

        public JObject responseJson;
        public async Task Post()
        {
            var response = await StaticManager.httpClient.PostAsync(StaticManager.apiUrl, parameters);
            var responseContent = await response.Content.ReadAsStringAsync();
            responseJson = JObject.Parse(responseContent);
        }

        public async Task Get()
        {
            string requestUrl = StaticManager.apiUrl + "?" + await parameters.ReadAsStringAsync();
            var response = await StaticManager.httpClient.GetAsync(requestUrl);
            var responseContent = await response.Content.ReadAsStringAsync();
            responseJson = JObject.Parse(responseContent);
        }
    }
}
