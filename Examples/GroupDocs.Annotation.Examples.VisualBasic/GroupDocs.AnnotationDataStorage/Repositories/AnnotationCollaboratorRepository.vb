Imports System.Linq
Imports GroupDocs.Annotation.Handler.Input.DataObjects
Imports GroupDocs.Annotation.Handler.Input

Namespace GroupDocs.Data.Json.Repositories
    Public Class AnnotationCollaboratorRepository
        Inherits JsonRepository(Of AnnotationCollaborator)
        Implements IAnnotationCollaboratorDataHandler
        Private Const _repoName As String = "GroupDocs.annotation.collaborators.json"

        Public Sub New(pathFinder As IRepositoryPathFinder)
            MyBase.New(pathFinder.Find(_repoName))
        End Sub

        Public Sub New(filePath As String)
            MyBase.New(filePath)
        End Sub

        Public Function GetDocumentCollaborators(documentId As Long) As AnnotationCollaborator() Implements IAnnotationCollaboratorDataHandler.GetDocumentCollaborators
            SyncLock _syncRoot
                Try
                    Return Data.Where(Function(x) x.DocumentId = documentId).ToArray()
                Catch e As Exception
                    Throw New DataJsonException("Failed to get document collaborators.", e)
                End Try
            End SyncLock
        End Function
    End Class
End Namespace