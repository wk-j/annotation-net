using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GroupDocs.Demo.Annotation.Webforms.Startup))]

namespace GroupDocs.Demo.Annotation.Webforms
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}