Imports System.Linq
Imports GroupDocs.Annotation.Handler.Input
Imports GroupDocs.Annotation.Handler.Input.DataObjects


Namespace GroupDocs.Data.Json.Repositories
    Public Class AnnotationRepository
        Inherits JsonRepository(Of DataObjects.Annotation)
        Implements IAnnotationDataHandler
        Private Const _repoName As String = "GroupDocs.annotations.json"

        Public Sub New(pathFinder As IRepositoryPathFinder)
            MyBase.New(pathFinder.Find(_repoName))
        End Sub

        Public Sub New(filePath As String)
            MyBase.New(filePath)
        End Sub

        Public Function GetAnnotation(guid As String) As DataObjects.Annotation Implements IAnnotationDataHandler.GetAnnotation
            SyncLock _syncRoot
                Try
                    Return Data.FirstOrDefault(Function(x) x.Guid = guid)
                Catch e As Exception
                    Throw New DataJsonException("Failed to get annotation by GUID.", e)
                End Try
            End SyncLock
        End Function
        Public Function GetDocumentAnnotations(documentId As Long, Optional pageNumber As System.Nullable(Of Integer) = Nothing) As DataObjects.Annotation() Implements IAnnotationDataHandler.GetDocumentAnnotations
            SyncLock _syncRoot
                Try
                    Return Data.Where(Function(x) x.DocumentId = documentId AndAlso (pageNumber Is Nothing OrElse x.PageNumber = pageNumber)).ToArray()


                Catch e As Exception
                    Throw New DataJsonException("Failed to get document annotations.", e)
                End Try
            End SyncLock
        End Function
    End Class
End Namespace