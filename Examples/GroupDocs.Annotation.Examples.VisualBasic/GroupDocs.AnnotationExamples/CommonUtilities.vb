Imports GroupDocs.Annotation.Config
Imports GroupDocs.Annotation.Domain
Imports GroupDocs.Annotation.Domain.Image
Imports GroupDocs.Annotation.Domain.Options
Imports GroupDocs.Annotation.Handler
Imports GroupDocs.Annotation.Handler.Input
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

'ExStart:CommonUtilities
Class CommonUtilities
    'ExStart:CommonProperties
    Private Const StorageFolderPath As String = "../../../../Data/Samples/"
    Private Const DestinationFolderPath As String = "../../../../Data/Output/"
    Private Const LicenseFilePath As String = "D://Groupdocs.Total.lic"
    'ExEnd:CommonProperties

    'ExStart:MapSourceFilePath
    ''' <summary>
    ''' Maps source file path
    ''' </summary>
    ''' <param name="SourceFileName">Source File Name</param>
    ''' <returns>Returns complete path of source file</returns>
    Public Shared Function MapSourceFilePath(SourceFileName As String) As String
        Try
            Return StorageFolderPath & SourceFileName
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
            Return exp.Message
        End Try
    End Function
    'ExEnd:MapSourceFilePath
    'ExStart:MapDestinationFilePath
    ''' <summary>
    ''' Maps destination file path
    ''' </summary>
    ''' <param name="DestinationFileName">Destination File Name</param>
    ''' <returns>Returns complete path of destination file</returns>
    Public Shared Function MapDestinationFilePath(DestinationFileName As String) As String
        Try
            Return DestinationFolderPath & DestinationFileName
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
            Return exp.Message
        End Try
    End Function
    'ExEnd:MapDestinationFilePath

    ''' <summary>
    ''' Saves output document
    ''' </summary>

    Public Shared Sub SaveOutputDocument(inputFile As Stream, annotations As List(Of AnnotationInfo), type As DocumentType)
        Try
            'ExStart:SaveOutputDocument
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            Dim documentRepository As IDocumentDataHandler = annotator.GetDocumentDataHandler()
            If Not Directory.Exists(cfg.StoragePath) Then
                Directory.CreateDirectory(cfg.StoragePath)
            End If

            Dim result As Stream = annotator.ExportAnnotationsToDocument(inputFile, annotations, type)

            Dim getFileStream As FileStream = TryCast(inputFile, FileStream)
            Dim extensionWithDot As String = Path.GetExtension(getFileStream.Name)

            ' Save result stream to file.
            Using fileStream As New FileStream(MapDestinationFilePath(Convert.ToString("Annotated") & extensionWithDot), FileMode.Create)
                Dim buffer As Byte() = New Byte(result.Length - 1) {}
                result.Seek(0, SeekOrigin.Begin)
                result.Read(buffer, 0, buffer.Length)
                fileStream.Write(buffer, 0, buffer.Length)
                fileStream.Close()
                'ExEnd:SaveOutputDocument
            End Using
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub


    'ExStart:ApplyLicense
    ''' <summary>
    ''' Applies product license
    ''' </summary>
    Public Shared Sub ApplyLicense()
        Try
            ' initialize License
            Dim lic As New License()
            ' apply license
            lic.SetLicense(LicenseFilePath)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub
    'ExEnd:ApplyLicense

    'ExStart:GetConfiguration
    ''' <summary>
    ''' Sets annotation configuration
    ''' </summary>
    ''' <returns>Returns AnnotationConfig object</returns>
    Public Shared Function GetConfiguration() As AnnotationConfig
        Try
            Dim cfg As New AnnotationConfig()

            'Set storage path 
            cfg.StoragePath = StorageFolderPath

            Return cfg
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
            Return Nothing
        End Try
    End Function
    'ExEnd:GetConfiguration

    'ExStart:GetImageRepresentation
    ''' <summary>
    ''' Gets image representation of document
    ''' </summary>
    ''' <param name="filePath">Source file path</param> 
    Public Shared Sub GetImageRepresentation(filePath As String)
        Try
            Dim document As Stream = New FileStream(MapSourceFilePath(filePath), FileMode.Open)
            Dim cfg As AnnotationConfig = GetConfiguration()

            Dim annotationHandler As New AnnotationImageHandler(cfg)

            Dim images As List(Of PageImage) = annotationHandler.GetPages(document, New ImageOptions())

            ' Save result stream to file.
            Using fileStream As New FileStream(MapDestinationFilePath("image.png"), FileMode.Create)
                Dim buffer As Byte() = New Byte(images(0).Stream.Length - 1) {}
                images(0).Stream.Seek(0, SeekOrigin.Begin)
                images(0).Stream.Read(buffer, 0, buffer.Length)
                fileStream.Write(buffer, 0, buffer.Length)
                fileStream.Close()
            End Using
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try

    End Sub
    'ExEnd:GetImageRepresentation

    'ExStart:GetTextCoordinatesInImage
    ''' <summary>
    ''' Gets text coordinates in image representation of document
    ''' </summary>
    ''' <param name="filePath">Source file path</param> 
    Public Shared Sub GetTextCoordinates(filePath As String)
        Try
            ' Set configuration
            Dim cfg As AnnotationConfig = GetConfiguration()

            ' Initialize annotator 
            Dim annotator As New AnnotationImageHandler(cfg)
            Try
                annotator.CreateDocument(filePath)
            Catch
            End Try

            Dim documentInfoContainer = annotator.GetDocumentInfo(filePath)

            ' Go through all pages
            For Each pageData As PageData In documentInfoContainer.Pages
                Console.WriteLine("Page number: " + pageData.Number)

                'Go through all page rows
                For i As Integer = 0 To pageData.Rows.Count - 1
                    Dim rowData As RowData = pageData.Rows(i)

                    ' Write data to console
                    Console.WriteLine("Row: " + (i + 1))
                    Console.WriteLine("Text: " + rowData.Text)
                    Console.WriteLine("Text width: " + rowData.LineWidth)
                    Console.WriteLine("Text height: " + rowData.LineHeight)
                    Console.WriteLine("Distance from left: " + rowData.LineLeft)
                    Console.WriteLine("Distance from top: " + rowData.LineTop)

                    ' Get words
                    Dim words As String() = rowData.Text.Split(" "c)

                    ' Go through all word coordinates
                    For j As Integer = 0 To words.Length - 1
                        Dim coordinateIndex As Integer = If(j = 0, 0, j + 1)
                        ' Write data to console
                        Console.WriteLine(String.Empty)
                        Console.WriteLine("Word:'" + words(j) + "'")
                        Console.WriteLine("Word distance from left: " + rowData.TextCoordinates(coordinateIndex))
                        Console.WriteLine("Word width: " + rowData.TextCoordinates(coordinateIndex + 1))
                        Console.WriteLine(String.Empty)
                    Next
                    Console.ReadKey()
                Next
            Next
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try

    End Sub
    'ExEnd:GetTextCoordinatesInImage
End Class
'ExEnd:CommonUtilities 