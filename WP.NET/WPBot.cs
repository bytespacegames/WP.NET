using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WP.NET.Actions;

namespace WP.NET
{
    public class WPBot
    {
        public string ownerAccountName;
        public string botName;

        private List<Listener> listeners;
        public WPBot(string username, string password, string url)
        {
            listeners = new List<Listener>();
            StaticManager.apiUrl = url;
            StaticManager.httpClient = new HttpClient();

            ownerAccountName = username.Split("@")[0];
            if (username.Contains("@"))
            {
                string[] sides = username.Split("@");
                botName = sides[sides.Length - 1];
            } else
            {
                string[] sides = password.Split("@");
                botName = sides[sides.Length - 1];
            }

            var task = Task.Run(async () => await StartBot(username,password));
        }

        public void AddListener(Listener listener)
        {
            listeners.Add(listener);
        }

        public async Task<string> RetrieveToken(string tokenType, string tokenID)
        {
            HTTPAction action = TokenAction.Token(tokenType);
            await action.Post();
            string token;

            try
            {
                token = action.responseJson["query"]["tokens"][tokenID].ToString();
            } catch (Exception e)
            {
                return null;
            }
            return token;
        }

        public async Task<string> GetCSRF()
        {
            return await RetrieveToken("csrf", "csrftoken");
        }

        public async Task StartBot(string username, string password)
        {
            var loginToken = await RetrieveToken("login", "logintoken");

            HTTPAction login = LoginAction.Login(username, password, loginToken);
            await login.Post();

            if (login.responseJson["login"]["result"].ToString() == "Success")
            {
                Console.WriteLine("Logged in successfully!");
                foreach (Listener listener in listeners) {
                    listener.OnBotStartAsync();
                }
            }
            else
            {
                Console.WriteLine("Login failed.");
            }
        }
    }
}
