using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.NET
{
    public class Listener
    {
        public virtual async Task OnBotStartAsync() { OnBotStart(); }
        public virtual void OnBotStart() { }
    }
}
