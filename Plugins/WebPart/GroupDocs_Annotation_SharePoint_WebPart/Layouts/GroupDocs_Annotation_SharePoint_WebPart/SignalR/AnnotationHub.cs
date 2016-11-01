using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;

namespace GroupDocs_Annotation_SharePoint_WebPart.SignalR
{
    public class AnnotationHub : Hub, IAnnotationHub
    {
        #region Fields
        private static volatile Dictionary<string, DocumentReviewer> _connectionsAndUserGuids;
        private IAuthenticationService _authenticationSvc;
        public static string userGUID;
        #endregion Fields

        static AnnotationHub()
        {
            _connectionsAndUserGuids = new Dictionary<string, DocumentReviewer>();
        }

        public AnnotationHub(IAuthenticationService authenticationSvc)
        {
            _authenticationSvc = authenticationSvc;
            try
            {
                var uid = userGUID;// "52ced024-26e0-4b59-a510-ca8f5368e315";
                var userGuid = (String.IsNullOrWhiteSpace(uid) ? _authenticationSvc.UserKey : uid);
                //string guid = new Guid().ToString();
                SetUserGuidForConnection(uid, userGuid);
            }
            catch (ArgumentException)
            {
                SetUserGuidForConnection(userGUID, _authenticationSvc.AnonymousUserKey);
            }
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            try
            {
                var uid = Context.QueryString["uid"];
                var userGuid = (String.IsNullOrWhiteSpace(uid) ? _authenticationSvc.UserKey : uid);
                SetUserGuidForConnection(userGUID, userGuid);
            }
            catch (ArgumentException)
            {
                SetUserGuidForConnection(userGUID, _authenticationSvc.AnonymousUserKey);
            }
            return null;
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            lock (_connectionsAndUserGuids)
            {
                _connectionsAndUserGuids.Remove(userGUID);
            }

            return null;
        }

        public void SetUserGuidForConnection(string connectionGuid, string userGuid)
        {
            lock (_connectionsAndUserGuids)
            {
                if (!(_connectionsAndUserGuids.ContainsKey(connectionGuid) && _connectionsAndUserGuids[connectionGuid].UserGuid == userGuid))
                {
                    _connectionsAndUserGuids[connectionGuid] = new DocumentReviewer() { UserGuid = userGuid };
                }
            }
        }

        public void SetDocumentGuidForConnection(string documentGuid)
        {
            string connectionGuid = userGUID;
            lock (_connectionsAndUserGuids)
            {
                DocumentReviewer documentReviewer = _connectionsAndUserGuids[connectionGuid];
                documentReviewer.DocumentGuid = documentGuid;
                _connectionsAndUserGuids[connectionGuid] = documentReviewer;
            }
        }


        public dynamic GetClient(string connectionId)
        {
            return Clients.Client(connectionId);
        }

        public string[] GetConnectionIdsToCall(string connectionIdToExclude, IList<string> collaboratorGuids)
        {
            lock (_connectionsAndUserGuids)
            {
                string documentGuid = (!String.IsNullOrEmpty(connectionIdToExclude) && _connectionsAndUserGuids.ContainsKey(connectionIdToExclude) ?
                    _connectionsAndUserGuids.First(x => x.Key == connectionIdToExclude).Value.DocumentGuid : String.Empty);
                return GetConnectionIdsToCall(connectionIdToExclude, collaboratorGuids, documentGuid);
            }
        }

        public string[] GetConnectionIdsToCall(string connectionIdToExclude, IList<string> collaboratorGuids, string documentGuid)
        {
            lock (_connectionsAndUserGuids)
            {
                string[] connectionIds =
                    _connectionsAndUserGuids.Where(x => x.Key != connectionIdToExclude
                        && collaboratorGuids.Contains(x.Value.UserGuid)
                        && x.Value.DocumentGuid == documentGuid).Select(x => x.Key).ToArray();
                return connectionIds;
            }
        }

        public DocumentReviewer? GetConnectionUser(string connectionId)
        {
            lock (_connectionsAndUserGuids)
            {
                return (_connectionsAndUserGuids.ContainsKey(connectionId) ?
                    new DocumentReviewer?(_connectionsAndUserGuids[connectionId]) : null);
            }
        }

        public void BroadcastDocumentScale(string userGuid, string privateKey, string fileGuid, double scale)
        {
            Clients.Others.setDocumentScaleOnClient(fileGuid, scale);
        }

        public void BroadcastDocumentScroll(string userGuid, string privateKey, string fileGuid,
                                            double horizontalScrollPortion, int verticalScrollPosition, double scale)
        {
            Clients.Others.setDocumentScrollOnClient(fileGuid, horizontalScrollPortion, verticalScrollPosition, scale);
        }

        public void BroadcastMouseCursorPosition(string userGuid, string privateKey, string fileGuid, double left, double top, double scale, double scrollTop)
        {
            Clients.Others.setMousePositionOnClient(fileGuid, left, top, scale, scrollTop);
        }

        public void BroadcastSlaveConnected(string fileGuid)
        {
            Clients.Others.slaveConnectedHandlerOnClient(fileGuid);
        }
    }
}