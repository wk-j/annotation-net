using System;
using System.Linq;
using GroupDocs.Annotation.Handler.Input;

namespace GroupDocs.Data.Json.Repositories
{
    public class AnnotationRepository : JsonRepository<GroupDocs.Annotation.Handler.Input.DataObjects.Annotation>, IAnnotationDataHandler
    {
        private const string _repoName = "GroupDocs.annotations.json";

        public AnnotationRepository(IRepositoryPathFinder pathFinder)
            : base(pathFinder.Find(_repoName))
        {
        }

        public AnnotationRepository(string filePath)
            : base(filePath)
        {
        }

        public GroupDocs.Annotation.Handler.Input.DataObjects.Annotation GetAnnotation(string guid)
        {
            lock (_syncRoot)
            {
                try
                {
                    return Data.FirstOrDefault(x => x.Guid == guid);
                }
                catch (Exception e)
                {
                    throw new DataJsonException("Failed to get annotation by GUID.", e);
                }
            }
        }
        public GroupDocs.Annotation.Handler.Input.DataObjects.Annotation[] GetDocumentAnnotations(long documentId, int? pageNumber = null)
        {
            lock (_syncRoot)
            {
                try
                {
                    return  Data
                        .Where(x => x.DocumentId == documentId && (pageNumber == null || x.PageNumber == pageNumber))
                        .ToArray();;
                }
                catch (Exception e)
                {
                    throw new DataJsonException("Failed to get document annotations.", e);
                }
            }
        }
    }
}
