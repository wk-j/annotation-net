#region Using Namespaces

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using GroupDocs.Annotation.Config;
using System.Web.Security;
using System.Web.Script.Serialization;
using GroupDocs.Annotation.Domain;
using GroupDocs.Annotation.Domain.Containers;
using GroupDocs.Annotation.Domain.Image;
using GroupDocs.Annotation.Domain.Options;
using GroupDocs.Annotation.Handler;
using GroupDocs.Demo.Annotation.Webforms.BusinessLogic;
using GroupDocs.Annotation;
using GroupDocs.Annotation.Exception;
using GroupDocs.Annotation.Handler.Input.DataObjects;
using GroupDocs.Demo.Annotation.Webforms.BusinessLogic.Options;
using GroupDocs.Demo.Annotation.Webforms.BusinessLogic.Responses;
using Microsoft.Practices.Unity;
using AnnotationReplyInfo = GroupDocs.Demo.Annotation.Webforms.AnnotationResults.Data.AnnotationReplyInfo;
using DeleteReplyResult = GroupDocs.Demo.Annotation.Webforms.AnnotationResults.DeleteReplyResult;
using Point = GroupDocs.Demo.Annotation.Webforms.AnnotationResults.DataGeometry.Point;
using Rectangle = GroupDocs.Demo.Annotation.Webforms.AnnotationResults.DataGeometry.Rectangle;
using RestoreRepliesResult = GroupDocs.Demo.Annotation.Webforms.AnnotationResults.RestoreRepliesResult;
using GroupDocs.Demo.Annotation.Webforms.SignalR;
using GroupDocs.Annotation.Common.License;

#endregion

namespace GroupDocs.Demo.Annotation.Webforms
{
    public partial class Default : System.Web.UI.Page
    {
        #region Static Fields

        private static EmbeddedResourceManager _resourceManager;
        private static IAnnotationService _annotationSvc;
        private static AnnotationImageHandler annotator;
        #endregion Fields

        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Register and initialize once only, all other methods will use and share same objects/configs.

                // initializing AnnotationImageHandler object.
                annotator = UnityConfig.GetConfiguredContainer().Resolve<AnnotationImageHandler>();

                // initializing EmbeddedResourceManager object.
                _resourceManager = new EmbeddedResourceManager();

                //AnnotationHub.userGUID = "52ced024-26e0-4b59-a510-ca8f5368e315";
                // initializing AnnotationService object.
                _annotationSvc = UnityConfig.GetConfiguredContainer().Resolve<IAnnotationService>();

                //Here you should apply proper GroupDocs.Annotation license (in case you want to
                //use this sample without trial limits)
                License lic = new License();
                lic.SetLicense("E:/GroupDocs.Total.lic");
            }
        }

        #endregion

        #region Annotaion Viewer Members

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetScript(string name)
        {
            string script = new EmbeddedResourceManager().GetScript(name);
            return script;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetCss(string name)
        {
            string css = new EmbeddedResourceManager().GetCss(name);
            return css;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static byte[] GetEmbeddedImage(string name)
        {
            byte[] imageBody = new EmbeddedResourceManager().GetBinaryResource(name);
            string mimeType = "image/png";
            return imageBody;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetTimes(int myinput, string myinput2, bool myinput3)
        {
            return "my success test txt.. : myinput:  " + myinput.ToString() + " myinput2: " + myinput2 + " myinput3:" + myinput3.ToString();
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ViewDocumentResponse ViewDocument(string path)
        {
            string request = path;

            string fileName = Path.GetFileName(request);
            var pathFinder = new ApplicationPathFinder();
            string _appPath = pathFinder.GetApplicationPath();
            ViewDocumentResponse result = new ViewDocumentResponse
            {
                pageCss = new string[] { },
                lic = true,
                pdfDownloadUrl = _appPath + "App_Data/" + request,
                url = _appPath + "App_Data/" + request,
                path = request,
                name = fileName
            };
            DocumentInfoContainer docInfo = annotator.GetDocumentInfo(request);
            result.documentDescription = new FileDataJsonSerializer(docInfo.Pages).Serialize(true);
            result.docType = docInfo.DocumentType;
            result.fileType = docInfo.FileType;

            List<PageImage> imagePages = annotator.GetPages(request);

            // Provide images urls
            List<string> urls = new List<string>();

            // If no cache - save images to temp folder
            string tempFolderPath = Path.Combine(HttpContext.Current.Server.MapPath("~"), "Content", "TempStorage");

            foreach (PageImage pageImage in imagePages)
            {
                string docFoldePath = Path.Combine(tempFolderPath, request);

                if (!Directory.Exists(docFoldePath))
                    Directory.CreateDirectory(docFoldePath);

                string pageImageName = string.Format("{0}\\{1}.png", docFoldePath, pageImage.PageNumber);

                using (Stream stream = pageImage.Stream)
                using (FileStream fileStream = new FileStream(pageImageName, FileMode.Create))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                }
                string baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";
                urls.Add(string.Format("{0}Content/TempStorage/{1}/{2}.png", baseUrl, request, pageImage.PageNumber));
            }

            result.imageUrls = urls.ToArray();

            // invoke event
            new DocumentOpenSubscriber().HandleEvent(request, _annotationSvc);

            return result;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static FileBrowserTreeDataResponse LoadFileBrowserTreeData(string path)
        {
            string parameters = "";

            string tempPath = AppDomain.CurrentDomain.GetData("DataDirectory") + "/";
            if (!string.IsNullOrEmpty(parameters))
                tempPath = Path.Combine(tempPath, parameters);

            FileTreeContainer tree = annotator.LoadFileTree(new FileTreeOptions(tempPath));
            List<FileDescription> treeNodes = tree.FileTree;
            FileBrowserTreeDataResponse data = new FileBrowserTreeDataResponse
            {
                nodes = ToFileTreeNodes(parameters, treeNodes).ToArray(),
                count = tree.FileTree.Count
            };

            return data;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static GetImageUrlsResponse GetImageUrls(string path)
        {
            string parameters = path;

            if (string.IsNullOrEmpty(parameters))
            {
                GetImageUrlsResponse empty = new GetImageUrlsResponse { imageUrls = new string[0] };

                return empty;
            }

            List<PageImage> imagePages = annotator.GetPages(parameters);

            // Save images some where and provide urls
            List<string> urls = new List<string>();
            string tempFolderPath = Path.Combine(HttpContext.Current.Server.MapPath("~"), "Content", "TempStorage");

            foreach (PageImage pageImage in imagePages)
            {
                string docFoldePath = Path.Combine(tempFolderPath, parameters);

                if (!Directory.Exists(docFoldePath))
                    Directory.CreateDirectory(docFoldePath);

                string pageImageName = string.Format("{0}\\{1}.png", docFoldePath, pageImage.PageNumber);

                using (Stream stream = pageImage.Stream)
                using (FileStream fileStream = new FileStream(pageImageName, FileMode.Create))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                }

                string baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";
                urls.Add(string.Format("{0}Content/TempStorage/{1}/{2}.png", baseUrl, parameters, pageImage.PageNumber));
            }

            GetImageUrlsResponse result = new GetImageUrlsResponse { imageUrls = urls.ToArray() };

            return result;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Stream GetFile(GetFileParameters parameters)
        {
            string displayName = string.IsNullOrEmpty(parameters.DisplayName) ?
                Path.GetFileName(parameters.Path) : Uri.EscapeDataString(parameters.DisplayName);

            Stream fileStream = annotator.GetFile(parameters.Path).Stream;

            //jquery.fileDownload uses this cookie to determine that a file download has completed successfully
            HttpContext.Current.Response.SetCookie(new HttpCookie("jqueryFileDownloadJSForGD", "true") { Path = "/" });

            return fileStream;
        }

        private static List<FileBrowserTreeNode> ToFileTreeNodes(string path, List<FileDescription> nodes)
        {
            return nodes.Select(_ =>
                new FileBrowserTreeNode
                {
                    path = string.IsNullOrEmpty(path) ? _.Name : string.Format("{0}/{1}", path, _.Name),
                    docType = string.IsNullOrEmpty(_.DocumentType) ? _.DocumentType : _.DocumentType.ToLower(),
                    fileType = string.IsNullOrEmpty(_.FileType) ? _.FileType : _.FileType.ToLower(),
                    name = _.Name,
                    size = _.Size,
                    modifyTime = (long)(_.LastModificationDate - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,
                    type = _.IsDirectory ? "folder" : "file"

                })
                .ToList();
        }


        private static string GetPdfDownloadUrl(ViewDocumentParameters request)
        {
            return GetFileUrl(request.Path, true, false, request.FileDisplayName,
                request.IgnoreDocumentAbsence,
                request.UseHtmlBasedEngine);
        }

        private static string GetFileUrl(ViewDocumentParameters request)
        {
            return GetFileUrl(request.Path, false, false, request.FileDisplayName);
        }

        public static string GetFileUrl(string path, bool getPdf, bool isPrintable, string fileDisplayName = null,
                               bool ignoreDocumentAbsence = false,
                               bool useHtmlBasedEngine = false)
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["path"] = path;
            if (!isPrintable)
            {
                queryString["getPdf"] = getPdf.ToString().ToLower();
                if (fileDisplayName != null)
                    queryString["displayName"] = fileDisplayName;
            }

            if (ignoreDocumentAbsence)
            {
                queryString["ignoreDocumentAbsence"] = ignoreDocumentAbsence.ToString().ToLower();
            }

            queryString["useHtmlBasedEngine"] = useHtmlBasedEngine.ToString().ToLower();

            string handlerName = isPrintable ? "GetPdfWithPrintDialog" : "GetFile";

            string baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";

            string fileUrl = string.Format("{0}{1}?{2}", baseUrl, handlerName, queryString);
            return fileUrl;
        }

        private static byte[] GetBytes(Stream input)
        {
            input.Position = 0;

            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        #endregion

        #region Annotation Members

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static AnnotationResults.CreateAnnotationResult CreateAnnotation(string connectionId, string userId, string privateKey,
            string fileId, byte type, string message, Rectangle rectangle, int pageNumber, Point annotationPosition, string svgPath,
            DrawingOptions drawingOptions, FontOptions font)
        {
            try
            {
                //_annotationSvc = UnityConfig.GetConfiguredContainer().Resolve<IAnnotationService>();

                var result = _annotationSvc.CreateAnnotation(connectionId, fileId, type, message, rectangle, pageNumber, annotationPosition, svgPath, drawingOptions, font);
                return result;
            }
            catch (AnnotatorException e)
            {
                throw e;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static AnnotationResults.DeleteAnnotationResult DeleteAnnotation(string connectionId, string userId, string privateKey, string fileId, string annotationGuid)
        {
            try
            {
                var result = _annotationSvc.DeleteAnnotation(connectionId, fileId, annotationGuid);
                return result;
            }
            catch (AnnotatorException e)
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static AnnotationResults.AddReplyResult AddAnnotationReply(string connectionId, string userId, string privateKey, string fileId, string annotationGuid, string message, string parentReplyGuid)
        {
            try
            {
                var result = _annotationSvc.AddAnnotationReply(connectionId, fileId, annotationGuid, message, parentReplyGuid);
                return result;
            }
            catch (AnnotatorException e)
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static AnnotationResults.DeleteReplyResult DeleteAnnotationReply(string connectionId, string userId, string privateKey, string fileId, string annotationGuid, string replyGuid)
        {
            try
            {
                DeleteReplyResult result = _annotationSvc.DeleteAnnotationReply(connectionId, fileId, annotationGuid, replyGuid);
                return result;
            }
            catch (AnnotatorException e)
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static AnnotationResults.EditReplyResult EditAnnotationReply(string connectionId, string userId, string privateKey, string fileId, string annotationGuid, string replyGuid, string message)
        {
            try
            {
                var result = _annotationSvc.EditAnnotationReply(connectionId, fileId, annotationGuid, replyGuid, message);
                return result;
            }
            catch (AnnotatorException e)
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static AnnotationResults.RestoreRepliesResult RestoreAnnotationReplies(string connectionId, string fileId, string annotationGuid, AnnotationReplyInfo[] replies)
        {
            try
            {
                var result = (replies == null || replies.Length == 0 ?
                    new RestoreRepliesResult { AnnotationGuid = annotationGuid, ReplyIds = new string[0] } :
                    _annotationSvc.RestoreAnnotationReplies(connectionId, fileId, annotationGuid, replies));
                return result;
            }
            catch (AnnotatorException e)
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static AnnotationResults.ListAnnotationsResult ListAnnotations(string connectionId, string userId, string privateKey, string fileId)
        {
            try
            {
                var result = _annotationSvc.ListAnnotations(connectionId, fileId);
                return result;
            }
            catch (AnnotatorException e)
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static AnnotationResults.ResizeAnnotationResult ResizeAnnotation(string connectionId, string fileId, string annotationGuid, double width, double height)
        {
            try
            {
                var result = _annotationSvc.ResizeAnnotation(connectionId, fileId, annotationGuid, width, height);
                return result;
            }
            catch (AnnotatorException e)
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static AnnotationResults.MoveAnnotationResult MoveAnnotationMarker(string connectionId, string userId, string privateKey, string fileId,
                                                 string annotationGuid, double left, double top, int? pageNumber)
        {
            try
            {
                var result = _annotationSvc.MoveAnnotationMarker(connectionId, fileId, annotationGuid, left, top, pageNumber);
                return result;
            }
            catch (AnnotatorException e)
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static AnnotationResults.SaveAnnotationTextResult SaveTextField(string connectionId, string userId, string privateKey, string fileId,
                                                       string annotationGuid, string text, string fontFamily, double fontSize)
        {
            try
            {
                var result = _annotationSvc.SaveTextField(connectionId, fileId, annotationGuid, text, fontFamily, fontSize);
                return result;
            }
            catch (AnnotatorException e)
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static AnnotationResults.SaveAnnotationTextResult SetTextFieldColor(string connectionId, string fileId, string annotationGuid, int fontColor)
        {
            try
            {
                var result = _annotationSvc.SetTextFieldColor(connectionId, fileId, annotationGuid, fontColor);
                return result;
            }
            catch (AnnotatorException e)
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static AnnotationResults.SaveAnnotationTextResult SetAnnotationBackgroundColor(string connectionId, string fileId, string annotationGuid, int color)
        {
            try
            {
                var result = _annotationSvc.SetAnnotationBackgroundColor(connectionId, fileId, annotationGuid, color);
                return result;
            }
            catch (AnnotatorException e)
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static AnnotationResults.GetCollaboratorsResult GetDocumentCollaborators(string userId, string privateKey, string fileId)
        {
            var result = _annotationSvc.GetCollaborators(fileId);
            return result;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static AnnotationResults.SetCollaboratorsResult AddDocumentReviewer(string userId, string privateKey,
            string fileId, string reviewerEmail, string reviewerFirstName, string reviewerLastName, string reviewerInvitationMessage)
        {
            var result = _annotationSvc.AddCollaborator(fileId, reviewerEmail, reviewerFirstName, reviewerLastName, reviewerInvitationMessage);
            return result;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static HtmlString ExportAnnotations(string connectionId, string fileId, string format, string mode)
        {
            try
            {
                string fileName = _annotationSvc.ExportAnnotations(connectionId, fileId);

                return new HtmlString(fileName);
            }
            catch (Exception e)
            {
                return new HtmlString("");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static FileResponse ImportAnnotations(string connectionId, string fileGuid)
        {
            try
            {
                _annotationSvc.ImportAnnotations(connectionId, fileGuid);
                return new FileResponse(fileGuid);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetPdfVersionOfDocument(string connectionId, string fileId)
        {
            try
            {
                var fileName = _annotationSvc.GetAsPdf(connectionId, fileId);
                return fileName;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static FileStream DownloadFile(string path)
        {
            var filePath = AppDomain.CurrentDomain.GetData("DataDirectory") + "/" + path;
            FileStream ff = File.OpenRead(filePath);
            return ff;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static FileResponse UploadFile(string user_id, string fld, string fileName, bool? multiple = false)
        {
            var user = UnityConfig.GetConfiguredContainer().Resolve<AnnotationImageHandler>().GetUserDataHandler().GetUserByGuid(user_id) ??
                       new User();
            try
            {
                var files = HttpContext.Current.Request.Files;
                var uploadDir = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data"), fld);
                var filePath = Path.Combine(uploadDir, fileName ?? files[0].FileName);

                Directory.CreateDirectory(uploadDir);

                using (var stream = System.IO.File.Create(filePath))
                {
                    ((multiple ?? false) ? HttpContext.Current.Request.InputStream : files[0].InputStream).CopyTo(stream);
                }

                var fileId = Path.Combine(fld, fileName ?? files[0].FileName);
                try
                {
                    annotator.CreateDocument(fileId, DocumentType.Pdf, user.Id);
                }
                catch (AnnotatorException e)
                {
                    if (annotator.RemoveDocument(fileId))
                    {
                        annotator.CreateDocument(fileId, DocumentType.Pdf, user.Id);
                    }
                }
                return new FileResponse(fileId);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static AnnotationResults.Data.ReviewerInfo GetAvatar(string userId)
        {
            var collaborator = _annotationSvc.GetCollaboratorMetadata(userId);
            if (collaborator == null || collaborator.Avatar == null)
            {
                return new AnnotationResults.Data.ReviewerInfo();
            }

            const string mimeType = "image/png";
            return collaborator;
        }

        #endregion Annotation members

    }
}