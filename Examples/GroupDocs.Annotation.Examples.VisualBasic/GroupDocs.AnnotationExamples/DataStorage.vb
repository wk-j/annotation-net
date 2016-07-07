Imports GroupDocs.Annotation.Config
Imports GroupDocs.Annotation.Domain
Imports GroupDocs.Annotation.Domain.Results
Imports GroupDocs.Annotation.Exception
Imports GroupDocs.Annotation.Handler
Imports GroupDocs.Annotation.Handler.Input
Imports GroupDocs.Annotation.Handler.Input.DataObjects
Imports GroupDocs.AnnotationDataStorage.GroupDocs.Data.Json
Imports GroupDocs.AnnotationDataStorage.GroupDocs.Data.Json.Repositories
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

'ExStart:DataStorageClass
Public Class DataStorage


    'ExStart:SourceDocFilePath
    ' initialize file path
    Private Const filePath As String = "sample.pdf"
    'ExEnd:SourceDocFilePath

    ''' <summary>
    ''' Picks the annotations from document.pdf and exports them to sample.pdf
    ''' </summary>
    Public Shared Sub ExportAnnotationInFile()
        Try
            'ExStart:ExportAnnotationInFile
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            ' Get file stream
            Dim manifestResourceStream As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)
            Dim annotations As New List(Of AnnotationInfo)()

            Dim stream As Stream = annotator.ExportAnnotationsToDocument(manifestResourceStream, annotations, DocumentType.Pdf)

            ' Save result stream to file.
            Using fileStream As New FileStream(CommonUtilities.MapDestinationFilePath("Annotated.pdf"), FileMode.Create)
                Dim buffer As Byte() = New Byte(stream.Length - 1) {}
                stream.Seek(0, SeekOrigin.Begin)
                stream.Read(buffer, 0, buffer.Length)
                fileStream.Write(buffer, 0, buffer.Length)
                fileStream.Close()
                'ExEnd:ExportAnnotationInFile
            End Using
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Creates a document data object in the storage
    ''' </summary>
    Public Shared Sub CreateDocument()
        Try
            'ExStart:CreateDocument
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("sample.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("sample.pdf"))

            'ExEnd:CreateDocument

            Console.WriteLine("Document ID : " + documentId)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Assigns/sets document access rights
    ''' </summary>
    Public Shared Sub AssignAccessRights()
        Try
            'ExStart:AssignAccessRight
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Set document access rights    
            'ExEnd:AssignAccessRight
            annotator.SetDocumentAccessRights(documentId, AnnotationReviewerRights.All)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Maps annotations and creates dcocument data object in the storage 
    ''' </summary>
    Public Shared Sub CreateAndGetAnnotation()
        Try
            'ExStart:CreateAndGetAnnotation
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Create annotation object
            Dim pointAnnotation As New AnnotationInfo() With { _
                 .AnnotationPosition = New Point(852.0, 81.0), _
                 .Box = New Rectangle(212.0F, 81.0F, 142.0F, 0.0F), _
                 .Type = AnnotationType.Point, _
                 .PageNumber = 0, _
                 .CreatorName = "Anonym", _
                 .DocumentGuid = documentId _
            }

            ' Add annotation to storage
            Dim createPointAnnotationResult As CreateAnnotationResult = annotator.CreateAnnotation(pointAnnotation)

            '=============================================================================
            ' Create annotation object
            Dim textFieldAnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 201.0), _
                .FieldText = "text in the box", _
                .FontFamily = "Arial", _
                .FontSize = 10, _
                .Box = New Rectangle(66.0F, 201.0F, 64.0F, 37.0F), _
                .PageNumber = 0, _
                .Type = AnnotationType.TextField, _
                .CreatorName = "Anonym", _
                .DocumentGuid = documentId _
            }

            'Add annotation to storage
            Dim createTextFieldAnnotationResult As CreateAnnotationResult = annotator.CreateAnnotation(textFieldAnnotation)

            ' Get annotation from storage
            'ExEnd:CreateAndGetAnnotation
            Dim result As GetAnnotationResult = annotator.GetAnnotation(createPointAnnotationResult.Guid)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Gets annotations from the storage file
    ''' </summary>
    ''' <returns>Returns a list of annotations</returns>
    Public Shared Function GetAllDocumentAnnotation() As ListAnnotationsResult
        Try
            'ExStart:GetAllAnnotation
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Get annotation from storage
            Dim result As ListAnnotationsResult = annotator.GetAnnotations(documentId)

            'ExEnd:GetAllAnnotation
            Return result
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Resizes the existing annotations
    ''' </summary>
    Public Shared Sub ResizeAnnotationResult()
        Try
            'ExStart:ResizeAnnotationResult
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Create annotation object
            Dim areaAnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 271.7), _
                .BackgroundColor = 3355443, _
                .Box = New Rectangle(466.0F, 271.0F, 69.0F, 62.0F), _
                .PageNumber = 0, _
                .PenColor = 3355443, _
                .Type = AnnotationType.Area, _
                .CreatorName = "Anonym", _
                .DocumentGuid = documentId _
            }

            'Add annotation to storage
            Dim createAreaAnnotationResult As CreateAnnotationResult = annotator.CreateAnnotation(areaAnnotation)

            'Resize annotation
            'ExEnd:ResizeAnnotationResult
            Dim resizeResult As ResizeAnnotationResult = annotator.ResizeAnnotation(createAreaAnnotationResult.Id, New AnnotationSizeInfo() With { _
                .Height = 80, _
                .Width = 60 _
            })
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Moves annotation marker
    ''' </summary>
    Public Shared Sub MoveAnnotationResult()
        Try
            'ExStart:MoveAnnotationResult
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Create annotation object
            Dim areaAnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 271.7), _
                .BackgroundColor = 3355443, _
                .Box = New Rectangle(466.0F, 271.0F, 69.0F, 62.0F), _
                .PageNumber = 0, _
                .PenColor = 3355443, _
                .Type = AnnotationType.Area, _
                .CreatorName = "Anonym", _
                .DocumentGuid = documentId _
            }

            'Add annotation to storage
            Dim createAreaAnnotationResult As CreateAnnotationResult = annotator.CreateAnnotation(areaAnnotation)

            'Move annotation marker
            'NewPageNumber
            'ExEnd:MoveAnnotationResult
            Dim moveAnnotationResult__1 As MoveAnnotationResult = annotator.MoveAnnotationMarker(createAreaAnnotationResult.Id, New Point(200, 200), 1)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Sets background color of annotation
    ''' </summary>
    Public Shared Sub SetBackgroundColorResult()
        Try
            'ExStart:SetBackgroundColorResult
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Create annotation object
            Dim textFieldAnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 201.0), _
                .FieldText = "text in the box", _
                .FontFamily = "Arial", _
                .FontSize = 10, _
                .Box = New Rectangle(66.0F, 201.0F, 64.0F, 37.0F), _
                .PageNumber = 0, _
                .Type = AnnotationType.TextField, _
                .CreatorName = "Anonym", _
                .DocumentGuid = documentId _
            }

            'Add annotation to storage
            Dim createTextFieldAnnotationResult As CreateAnnotationResult = annotator.CreateAnnotation(textFieldAnnotation)

            ' Set background color of annotation
            'ExEnd:SetBackgroundColorResult
            Dim setBackgroundColorResult__1 As SaveAnnotationTextResult = annotator.SetAnnotationBackgroundColor(createTextFieldAnnotationResult.Id, 16711680)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Updates the text in the annotation
    ''' </summary>
    Public Shared Sub EditTextFieldAnnotation()
        Try
            'ExStart:EditTextFieldAnnotation
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Create annotation object
            Dim textFieldAnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 201.0), _
                .FieldText = "text in the box", _
                .FontFamily = "Arial", _
                .FontSize = 10, _
                .Box = New Rectangle(66.0F, 201.0F, 64.0F, 37.0F), _
                .PageNumber = 0, _
                .Type = AnnotationType.TextField, _
                .CreatorName = "Anonym", _
                .DocumentGuid = documentId _
            }

            'Add annotation to storage
            Dim createTextFieldAnnotationResult As CreateAnnotationResult = annotator.CreateAnnotation(textFieldAnnotation)

            ' Update text in the annotation
            Dim saveTextFieldResult As SaveAnnotationTextResult = annotator.SaveTextField(createTextFieldAnnotationResult.Id, New TextFieldInfo() With { _
                .FieldText = "new text", _
                .FontFamily = "Colibri", _
                .FontSize = 12 _
            })


            ' Set text field color
            'ExEnd:EditTextFieldAnnotation
            Dim saveTextFieldColorResult As SaveAnnotationTextResult = annotator.SetTextFieldColor(createTextFieldAnnotationResult.Id, 16753920)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Removes annotations
    ''' </summary>
    Public Shared Sub RemoveAnnotation()
        Try
            'ExStart:RemoveAnnotation
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            ' Create document data object in storage.
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Create annotation object
            Dim pointAnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 81.0), _
                .Box = New Rectangle(212.0F, 81.0F, 142.0F, 0.0F), _
                .Type = AnnotationType.Point, _
                .PageNumber = 0, _
                .CreatorName = "Anonym", _
                .DocumentGuid = documentId _
            }

            ' Get all annotations from storage
            Dim listAnnotationsResult As ListAnnotationsResult = annotator.GetAnnotations(documentId)

            ' Get annotation  
            Dim annotation = annotator.GetAnnotation(listAnnotationsResult.Annotations(0).Guid)


            ' Delete single annotation
            Dim deleteAnnotationResult = annotator.DeleteAnnotation(annotation.Id)

            'Delete all annotations
            'ExEnd:RemoveAnnotation
            annotator.DeleteAnnotations(documentId)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds reply to the annotation, edits reply, creates child reply
    ''' </summary>
    Public Shared Sub AddAnnotationReply()
        Try
            'ExStart:AddAnnotationReply
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            ' Create document data object in storage
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf"))

            ' Create annotation object
            Dim pointAnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 81.0), _
                .Box = New Rectangle(212.0F, 81.0F, 142.0F, 0.0F), _
                .Type = AnnotationType.Point, _
                .PageNumber = 0, _
                .CreatorName = "Anonym", _
                .DocumentGuid = documentId _
            }

            ' Add annotation to storage
            Dim createPointAnnotationResult = annotator.CreateAnnotation(pointAnnotation)

            ' Add simple reply to created annotation
            Dim addSimpleReplyResult = annotator.CreateAnnotationReply(createPointAnnotationResult.Id, "first question")

            ' Edit created reply
            Dim editReplyResult = annotator.EditAnnotationReply(addSimpleReplyResult.ReplyGuid, "changed question")

            ' Create child reply. This reply will be linked to previously created reply.
            Dim addChildReplyResult = annotator.CreateAnnotationReply(createPointAnnotationResult.Id, "answer", addSimpleReplyResult.ReplyGuid)

            ' Delete annotation reply by guid
            Dim deleteReplyResult = annotator.DeleteAnnotationReply(addChildReplyResult.ReplyGuid)

            ' Delete all replies from annotation
            annotator.DeleteAnnotationReplies(createPointAnnotationResult.Id)

            ' List of replies after deleting all replies
            'ExEnd:AddAnnotationReply
            Dim listRepliesResultAfterDeleteAll = annotator.ListAnnotationReplies(createPointAnnotationResult.Id)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds document collaborator 
    ''' </summary>
    Public Shared Sub AddCollaborator()
        Try
            'ExStart:AddCollaborator 
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            Dim userRepository As IUserDataHandler = annotator.GetUserDataHandler()

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            ' Create a user that will be an owner.           
            ' Get user from the storage 
            Dim owner = userRepository.GetUserByEmail("john@doe.com")

            ' If user doesn’t exist in the storage then create it. 
            If owner Is Nothing Then
                userRepository.Add(New User() With { _
                    .FirstName = "John", _
                    .LastName = "Doe", _
                    .Email = "john@doe.com" _
                })
                owner = userRepository.GetUserByEmail("john@doe.com")
            End If

            ' Get document data object in the storage
            Dim document = documentRepository.GetDocument("Document.pdf")

            ' If document already created or it hasn’t owner then delete document
            If document IsNot Nothing AndAlso document.OwnerId <> owner.Id Then
                documentRepository.Remove(document)
                document = Nothing
            End If

            ' Get document id if document already created or create new document
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf", DocumentType.Pdf, owner.Id))

            ' Create reviewer. 
            'user email, unique identifier
            Dim reviewerInfo = New ReviewerInfo() With { _
                .PrimaryEmail = "judy@doe.com", _
                .FirstName = "Judy", _
                .LastName = "Doe", _
                .AccessRights = AnnotationReviewerRights.All _
            }

            ' Add collaboorator to the document. If user with Email equals to reviewers PrimaryEmail is absent it will be created.
            'ExEnd:AddCollaborator                
            Dim addCollaboratorResult = annotator.AddCollaborator(documentId, ReviewerInfo)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Gets document collaborator 
    ''' </summary>
    Public Shared Sub GetCollaborator()
        Try
            'ExStart:GetCollaborator 
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            'Create annotation handler
            Dim annotator As New AnnotationImageHandler(cfg)

            Dim userRepository As IUserDataHandler = annotator.GetUserDataHandler()

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            ' Create a user that will be an owner.           
            ' Get user from the storage 
            Dim owner = userRepository.GetUserByEmail("john@doe.com")

            ' If user doesn’t exist in the storage then create it. 
            If owner Is Nothing Then
                userRepository.Add(New User() With { _
                    .FirstName = "John", _
                    .LastName = "Doe", _
                    .Email = "john@doe.com" _
                })
                owner = userRepository.GetUserByEmail("john@doe.com")
            End If

            ' Get document data object in the storage
            Dim document = documentRepository.GetDocument("Document.pdf")

            ' If document already created or it hasn’t owner then delete document
            If document IsNot Nothing AndAlso document.OwnerId <> owner.Id Then
                documentRepository.Remove(document)
                document = Nothing
            End If

            ' Get document id if document already created or create new document
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf", DocumentType.Pdf, owner.Id))

            ' Create reviewer. 
            'user email, unique identifier
            Dim reviewerInfo = New ReviewerInfo() With { _
                .PrimaryEmail = "judy@doe.com", _
                .FirstName = "Judy", _
                .LastName = "Doe", _
                .AccessRights = AnnotationReviewerRights.All _
            }

            ' Get document collaborators.
            Dim getCollaboratorsResult = annotator.GetCollaborators(documentId)

            ' Get document collaborator by email
            Dim getCollaboratorsResultByEmail = annotator.GetDocumentCollaborator(documentId, ReviewerInfo.PrimaryEmail)

            ' Get collaborator metadata 
            Dim user = userRepository.GetUserByEmail(ReviewerInfo.PrimaryEmail)
            'ExEnd:GetCollaborator                
            Dim collaboratorMetadataResult As ReviewerInfo = annotator.GetCollaboratorMetadata(user.Guid)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Updates document collaborator 
    ''' </summary>
    Public Shared Sub UpdateCollaborator()
        Try
            'ExStart:UpdateCollaborator
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            'Create annotation handler
            Dim annotator As New AnnotationImageHandler(cfg)

            Dim userRepository As IUserDataHandler = annotator.GetUserDataHandler()

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            ' Create a user that will be an owner.           
            ' Get user from the storage 
            Dim owner = userRepository.GetUserByEmail("john@doe.com")

            ' If user doesn’t exist in the storage then create it. 
            If owner Is Nothing Then
                userRepository.Add(New User() With { _
                    .FirstName = "John", _
                    .LastName = "Doe", _
                    .Email = "john@doe.com" _
                })
                owner = userRepository.GetUserByEmail("john@doe.com")
            End If

            ' Get document data object in the storage
            Dim document = documentRepository.GetDocument("Document.pdf")

            ' If document already created or it hasn’t owner then delete document
            If document IsNot Nothing AndAlso document.OwnerId <> owner.Id Then
                documentRepository.Remove(document)
                document = Nothing
            End If

            ' Get document id if document already created or create new document
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf", DocumentType.Pdf, owner.Id))

            ' Create reviewer. 
            'user email, unique identifier
            Dim reviewerInfo = New ReviewerInfo() With { _
                .PrimaryEmail = "judy@doe.com", _
                .FirstName = "Judy", _
                .LastName = "Doe", _
                .AccessRights = AnnotationReviewerRights.All _
            }
            ' Update collaborator. Only color and access rights will be updated.
            ReviewerInfo.Color = 3355443
            'ExEnd:UpdateCollaborator            
            Dim updateCollaboratorResult = annotator.UpdateCollaborator(documentId, ReviewerInfo)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Deletes document collaborator 
    ''' </summary>
    Public Shared Sub DeleteCollaborator()
        Try
            'ExStart:DeleteCollaborator
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            'Create annotation handler
            Dim annotator As New AnnotationImageHandler(cfg)

            Dim userRepository As IUserDataHandler = annotator.GetUserDataHandler()

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            ' Create a user that will be an owner.           
            ' Get user from the storage 
            Dim owner = userRepository.GetUserByEmail("john@doe.com")

            ' If user doesn’t exist in the storage then create it. 
            If owner Is Nothing Then
                userRepository.Add(New User() With { _
                    .FirstName = "John", _
                    .LastName = "Doe", _
                    .Email = "john@doe.com" _
                })
                owner = userRepository.GetUserByEmail("john@doe.com")
            End If

            ' Get document data object in the storage
            Dim document = documentRepository.GetDocument("Document.pdf")

            ' If document already created or it hasn’t owner then delete document
            If document IsNot Nothing AndAlso document.OwnerId <> owner.Id Then
                documentRepository.Remove(document)
                document = Nothing
            End If

            ' Get document id if document already created or create new document
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf", DocumentType.Pdf, owner.Id))

            ' Create reviewer. 
            'user email, unique identifier
            Dim reviewerInfo = New ReviewerInfo() With { _
                .PrimaryEmail = "judy@doe.com", _
                .FirstName = "Judy", _
                .LastName = "Doe", _
                .AccessRights = AnnotationReviewerRights.All _
            }

            ' Delete collaborator
            'ExEnd:DeleteCollaborator
            Dim deleteCollaboratorResult = annotator.DeleteCollaborator(documentId, ReviewerInfo.PrimaryEmail)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Manages collaborator rights 
    ''' </summary>
    Public Shared Sub ManageCollaboratorRights()
        Try
            'ExStart:ManageCollaboratorRights
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            'Create annotation handler
            Dim annotator As New AnnotationImageHandler(cfg)

            Dim userRepository As IUserDataHandler = annotator.GetUserDataHandler()

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            ' Create owner. 
            Dim johnOwner = userRepository.GetUserByEmail("john@doe.com")
            If johnOwner Is Nothing Then
                userRepository.Add(New User() With { _
                    .FirstName = "John", _
                    .LastName = "Doe", _
                    .Email = "john@doe.com" _
                })
                johnOwner = userRepository.GetUserByEmail("john@doe.com")
            End If

            ' Create document data object in storage
            Dim document = documentRepository.GetDocument("Document.pdf")
            Dim documentId As Long = If(document IsNot Nothing, document.Id, annotator.CreateDocument("Document.pdf", DocumentType.Pdf, johnOwner.Id))

            ' Create reviewer. 

            ' Can only get view annotations
            Dim reviewerInfo = New ReviewerInfo() With { _
                .PrimaryEmail = "judy@doe.com", _
                .FirstName = "Judy", _
                .LastName = "Doe", _
                .AccessRights = AnnotationReviewerRights.CanView _
            }

            ' Add collaboorator to the document. If user with Email equals to reviewers PrimaryEmail is absent it will be created.
            Dim addCollaboratorResult = annotator.AddCollaborator(documentId, ReviewerInfo)

            ' Get document collaborators
            Dim getCollaboratorsResult = annotator.GetCollaborators(documentId)
            Dim judy = userRepository.GetUserByEmail("judy@doe.com")

            ' Create annotation object
            Dim pointAnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 81.0), _
                .Box = New Rectangle(212.0F, 81.0F, 142.0F, 0.0F), _
                .Type = AnnotationType.Point, _
                .PageNumber = 0, _
                .CreatorName = "Anonym A." _
            }

            ' John try to add annotations. User is owner of the document.
            Dim johnResult = annotator.CreateAnnotation(pointAnnotation, documentId, johnOwner.Id)

            ' Judy try to add annotations
            Try
                Dim judyResult = annotator.CreateAnnotation(pointAnnotation, documentId, judy.Id)

                'Get exceptions, because user can only view annotations
            Catch e As AnnotatorException
                Console.Write(e.Message)
                Console.ReadKey()
            End Try

            ' Allow Judy create annotations.
            ReviewerInfo.AccessRights = AnnotationReviewerRights.CanAnnotate
            Dim updateCollaboratorResult = annotator.UpdateCollaborator(documentId, ReviewerInfo)

            ' Now user can add annotations
            'ExEnd:ManageCollaboratorRights
            Dim judyResultCanAnnotate = annotator.CreateAnnotation(pointAnnotation, documentId, judy.Id)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub
End Class
'ExEnd:DataStorageClass 