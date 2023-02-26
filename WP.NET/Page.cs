using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.NET.Actions;

namespace WP.NET
{
    public class Page
    {
        public readonly string name;
        private int pageId = -1337;

        public async Task<string> GetContent()
        {
            HTTPAction action = ContentGetAction.Content(name);
            await action.Post();

            var page = action.responseJson["query"]["pages"][0];
            if (page["missing"] != null)
            {
                return null;
            }
            else
            {
                var htmlContent = action.responseJson["query"]["pages"][0]["revisions"][0]["slots"]["main"]["content"].ToString();
                return htmlContent;
            }
        }

        public Page(string name)
        {
            this.name = name;
        }

        public async Task SetContent(string content)
        {
            HTTPAction set = await ContentSetAction.SetContent(name, content);
            await set.Post();
        }
        
        //shit var name ik but idc
        public async Task Append(string stringToAppendToContent)
        {
            string content = await GetContent();
            content += stringToAppendToContent;
            await SetContent(content);
        }
        public async Task<int> GetPageID()
        {
            if (pageId != -1337) { return pageId; }
            HTTPAction action = PageIDQueryAction.Query(name);
            await action.Get();
            pageId = action.responseJson["query"]["pages"][0]["pageid"].ToObject<int>();
            return pageId;
        }
    }
}
