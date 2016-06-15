Imports GroupDocs.Annotation.Handler.Input.DataObjects
Imports GroupDocs.Annotation.Handler.Input

Namespace GroupDocs.Data.Json.Repositories
    Public Class DocumentRepository
        Inherits JsonRepository(Of Document)
        Implements IDocumentDataHandler
        Private Const _repoName As String = "GroupDocs.annotation.documents.json"

        Public Sub New(pathFinder As IRepositoryPathFinder)
            MyBase.New(pathFinder.Find(_repoName))
        End Sub

        Public Sub New(filePath As String)
            MyBase.New(filePath)
        End Sub

        Public Function GetDocument(name As String) As Document Implements IDocumentDataHandler.GetDocument
            SyncLock _syncRoot
                Try
                    Return Data.Find(Function(x) x.Name = name)
                Catch e As Exception
                    Throw New DataJsonException("Failed to get document by id.", e)
                End Try
            End SyncLock
        End Function
    End Class
End Namespace