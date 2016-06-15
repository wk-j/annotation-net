using System;
using System.Linq;
using GroupDocs.Annotation.Handler.Input.DataObjects;
using GroupDocs.Annotation.Handler.Input;

namespace GroupDocs.Data.Json.Repositories
{
    public class AnnotationCollaboratorRepository : JsonRepository<AnnotationCollaborator>, IAnnotationCollaboratorDataHandler
    {
        private const string _repoName = "GroupDocs.annotation.collaborators.json";

        public AnnotationCollaboratorRepository(IRepositoryPathFinder pathFinder)
            : base(pathFinder.Find(_repoName))
        {
        }

        public AnnotationCollaboratorRepository(string filePath)
            : base(filePath)
        {
        }

        public AnnotationCollaborator[] GetDocumentCollaborators(long documentId)
        {
            lock (_syncRoot)
            {
                try
                {
                    return Data.Where(x => x.DocumentId == documentId).ToArray();
                }
                catch (Exception e)
                {
                    throw new DataJsonException("Failed to get document collaborators.", e);
                }
            }
        }
    }
}
