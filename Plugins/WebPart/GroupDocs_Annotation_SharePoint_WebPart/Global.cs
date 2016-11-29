using System;
using System.Web.Routing;
using GroupDocs_Annotation_SharePoint_WebPart.BusinessLogic;
using Microsoft.AspNet.SignalR;
using Microsoft.Practices.Unity;


namespace GroupDocs_Annotation_SharePoint_WebPart
{
    public class Global : Microsoft.SharePoint.ApplicationRuntime.SPHttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

            // Map signalr routes
            RouteTable.Routes.MapHubs("/_layouts/15/GroupDocs_Annotation_SharePoint_WebPart/signalr1_1_2", new HubConfiguration { EnableCrossDomain = true, EnableJavaScriptProxies = true, EnableDetailedErrors = false });

            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(300);
            GlobalHost.DependencyResolver.Register(
                typeof(AnnotationHub),
                () => new AnnotationHub(UnityConfig.GetConfiguredContainer().Resolve<IAuthenticationService>()));
        }
    }
}
