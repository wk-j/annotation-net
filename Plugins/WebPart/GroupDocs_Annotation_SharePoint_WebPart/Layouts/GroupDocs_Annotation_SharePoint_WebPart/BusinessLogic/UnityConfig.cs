using System;
using System.Web;
using GroupDocs.Annotation.Config;
using GroupDocs.Annotation.Handler;
using GroupDocs.Annotation.Handler.Input;
using GroupDocs_Annotation_SharePoint_WebPart.Security;
using GroupDocs_Annotation_SharePoint_WebPart.Service;
using Microsoft.Practices.Unity;



namespace GroupDocs_Annotation_SharePoint_WebPart.BusinessLogic
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        private static ApplicationPathFinder pathFinder = new ApplicationPathFinder();
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);

            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            container.RegisterType<IHtmlString, AnnotationWidget>("AnnotationWidget");

            string repositoryFolder = HttpContext.Current.Server.MapPath("~/_layouts/15/GroupDocs_Annotation_SharePoint_WebPart/App_Data");
            var annotator = new AnnotationImageHandler(
               new AnnotationConfig { StoragePath = repositoryFolder },
                new GroupDocs.Data.Json.Repositories.UserRepository(repositoryFolder),
                new GroupDocs.Data.Json.Repositories.DocumentRepository(repositoryFolder),
                new GroupDocs.Data.Json.Repositories.AnnotationRepository(repositoryFolder),
                new GroupDocs.Data.Json.Repositories.AnnotationReplyRepository(repositoryFolder),
                new GroupDocs.Data.Json.Repositories.AnnotationCollaboratorRepository(repositoryFolder));


            container.RegisterInstance(typeof(IUserDataHandler), annotator.GetUserDataHandler());


            #region Instances
            //container.RegisterInstance(typeof (IDocumentDataHandler), new DocumentRepository(repositoryFolder));
            //container.RegisterInstance(typeof(IAnnotationCollaboratorDataHandler), new AnnotationCollaboratorRepository(repositoryFolder));
            //container.RegisterInstance(typeof(IAnnotationReplyDataHandler), new AnnotationReplyRepository(repositoryFolder));
            //container.RegisterInstance(typeof(IAnnotationDataHandler), new AnnotationRepository(repositoryFolder));
            //container.RegisterInstance(typeof(IInputDataHandler), new InputDataHandler(repositoryFolder));
            //container.RegisterInstance(typeof(IFileDataStore), new FileStore(repositoryFolder));
            #endregion Instances


            container.RegisterInstance(typeof(AnnotationImageHandler), annotator);

            container.RegisterType<IAnnotationService, AnnotationService>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<IAnnotationBroadcaster, AnnotationBroadcaster>();
            container.RegisterType<IAnnotationHub, AnnotationHub>();
        }
    }
}
