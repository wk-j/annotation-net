Imports GroupDocs.Annotation.Handler.Input
Imports GroupDocs.Annotation.Handler.Input.DataObjects

Namespace GroupDocs.Data.Json.Repositories
    Public Class UserRepository
        Inherits JsonRepository(Of User)
        Implements IUserDataHandler
        Private Const _repoName As String = "GroupDocs.users.json"

        Public Sub New(pathFinder As IRepositoryPathFinder)
            MyBase.New(pathFinder.Find(_repoName))
        End Sub
        Public Function GetUserByGuid(guid As String) As User Implements IUserDataHandler.GetUserByGuid
            SyncLock _syncRoot
                Try
                    Return Data.Find(Function(x) x.Guid = guid)
                Catch e As Exception
                    Throw New DataJsonException("Failed to get user by GUID.", e)
                End Try
            End SyncLock
        End Function

        Public Function GetUserByEmail(email As String) As User Implements IUserDataHandler.GetUserByEmail
            SyncLock _syncRoot
                Try
                    Return Data.Find(Function(x) x.Email = email)
                Catch e As Exception
                    Throw New DataJsonException("Failed to get user by name.", e)
                End Try
            End SyncLock
        End Function
    End Class
End Namespace