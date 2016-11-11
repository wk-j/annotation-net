using System;
using System.Web.Routing;
using GroupDocs.Demo.Annotation.Webforms.BusinessLogic;
using GroupDocs.Demo.Annotation.Webforms.SignalR;
using Microsoft.AspNet.SignalR;
using Microsoft.Practices.Unity;


namespace GroupDocs.Demo.Annotation.Webforms
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Map signalr routes
            RouteTable.Routes.MapHubs("/signalr1_1_2", new HubConfiguration { EnableCrossDomain = true });

            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(300);
            GlobalHost.DependencyResolver.Register(
                typeof(AnnotationHub),
                () => new AnnotationHub(UnityConfig.GetConfiguredContainer().Resolve<IAuthenticationService>()));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}