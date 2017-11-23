using System.Web.Mvc;
using GroupDocs_Annotation_SharePoint_WebPart.BusinessLogic;
using Microsoft.Practices.Unity;

namespace GroupDocs_Annotation_SharePoint_WebPart
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Creates an instance of an object rendering annotation JavaScript code
        /// </summary>
        /// <returns>An instance of the JavaScript rendering object</returns>
        public static AnnotationScripts AnnotationScripts()
        {
            return new AnnotationScripts();
        }

        /// <summary>
        /// Creates an instance of an object creating annotation widget HTML code
        /// </summary>
        /// <returns>An instance of the HTML code creation object</returns>
        public static AnnotationWidget Annotation()
        {
            return UnityConfig.GetConfiguredContainer().Resolve<AnnotationWidget>();
        }
    }
}
