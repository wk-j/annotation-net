using System.Collections.Generic;

namespace GroupDocs_Annotation_SharePoint_WebPart
{

    public interface IAnnotationHub
    {
        void SetUserGuidForConnection(string connectionGuid, string userGuid);
        string[] GetConnectionIdsToCall(string connectionIdToExclude, IList<string> collaboratorGuids);
        string[] GetConnectionIdsToCall(string connectionIdToExclude, IList<string> collaboratorGuids, string documentGuid);
        DocumentReviewer? GetConnectionUser(string connectionId);
    }
}
