using System.Web;
using GroupDocs_Annotation_SharePoint_WebPart.BusinessLogic;
using Microsoft.Practices.Unity;

namespace GroupDocs_Annotation_SharePoint_WebPart.BusinessLogic
{
    internal class DocumentOpenSubscriber
    {
        public void HandleEvent(string path, IAnnotationService svc)
        {
            var un = HttpContext.Current.Session["UserName"] != null ? HttpContext.Current.Session["UserName"].ToString() : "";
            //var svc = UnityConfig.GetConfiguredContainer().Resolve<IAnnotationService>();
            if (!string.IsNullOrEmpty(un))
            {
                // add user to the document collaborator list
                svc.AddCollaborator(path, un, null, null, null);
            }
            else
            {
                svc.AddCollaborator(path, "GroupDocs@GroupDocs.com", "Anonym", "A.", null); // allow anonymous users to annotate on a document
            }
        }
    }
}