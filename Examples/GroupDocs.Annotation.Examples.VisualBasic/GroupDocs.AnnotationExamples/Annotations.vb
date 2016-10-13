Imports GroupDocs.Annotation.Config
Imports GroupDocs.Annotation.Domain
Imports GroupDocs.Annotation.Handler
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

'ExStart:AllAnnotations
Public Class Annotations
    ' initialize file path
    'ExStart:SourceDocFilePath
    Private Const filePath As String = "Annotated.docx"
    'ExEnd:SourceDocFilePath

    ''' <summary>
    ''' Adds text annotation in PDF document
    ''' </summary>
    Public Shared Sub AddTextAnnotation()
        Try
            'ExStart:AddTextAnnotation
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Initialize text annotation.
            Dim textAnnotation As New AnnotationInfo() With { _
                .Box = New Rectangle(CSng(265.44), CSng(153.86), 206, 36), _
                .PageNumber = 0, _
                .SvgPath = "[{""x"":265.44,""y"":388.83},{""x"":472.19,""y"":388.83},{""x"": 265.44,""y"":349.14},{""x"":472.19,""y"":349.14}]", _
                .Type = AnnotationType.Text, _
                .CreatorName = "Anonym A." _
            }

            ' Add annotation to list
            annotations.Add(textAnnotation)

            ' Export annotation and save output file
            'ExEnd:AddTextAnnotation
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub


    ''' <summary>
    ''' Add text annotation in cells
    ''' </summary>
    ''' Update filePath with path to Cells file before using this function
    Public Shared Sub AddTextAnnotationInCells()
        Try
            'ExStart:AddTextAnnotationInCells
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Initialize text annotation.
            Dim textAnnotation As New AnnotationInfo() With { _
                 .PageNumber = 1, _
                 .AnnotationPosition = New Point(3, 3), _
                 .FieldText = "Hello!" _
            }

            ' Add annotation to list
            annotations.Add(textAnnotation)

            ' Export annotation and save output file
            'ExEnd:AddTextAnnotationInCells
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Cells)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Add text annotation in slides
    ''' </summary>
    ''' Update filePath with path to Slides file before using this function
    Public Shared Sub AddTextAnnotationInSlides()
        Try
            'ExStart:AddTextAnnotationInSlides
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Initialize text annotation.
            Dim textAnnotation As New AnnotationInfo() With { _
                 .PageNumber = 0, _
                 .AnnotationPosition = New Point(1, 2), _
                 .FieldText = "Hello!", _
                 .CreatorName = "John" _
            }

            ' Add annotation to list
            annotations.Add(textAnnotation)

            ' Export annotation and save output file
            'ExEnd:AddTextAnnotationInSlides
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Slides)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub


    ''' <summary>
    ''' Adds area annotation with replies in PDF document
    ''' </summary>
    Public Shared Sub AddAreaAnnotationWithReplies()
        Try
            'ExStart:AddAreaAnnotationWithReplies
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Area annotation with 2 replies
            Dim areaAnnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 59.0), _
                .Replies = New AnnotationReplyInfo() {New AnnotationReplyInfo() With { _
                    .Message = "Hello!", _
                    .RepliedOn = DateTime.Now, _
                    .UserName = "John" _
                }, New AnnotationReplyInfo() With { _
                    .Message = "Hi!", _
                    .RepliedOn = DateTime.Now, _
                    .UserName = "Judy" _
                }}, _
                .BackgroundColor = 11111111, _
                .Box = New Rectangle(300.0F, 200.0F, 88.0F, 37.0F), _
                .PageNumber = 0, _
                .PenColor = 2222222, _
                .PenStyle = 1, _
                .PenWidth = 1, _
                .Type = AnnotationType.Area, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(areaAnnnotation)

            ' Export annotation and save output file
            'ExEnd:AddAreaAnnotationWithReplies
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds point annotation in PDF document
    ''' </summary>
    Public Shared Sub AddPointAnnotation()
        Try
            'ExStart:AddPointAnnotation
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)
            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Point annotation
            Dim pointAnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 81.0), _
                .Box = New Rectangle(212.0F, 81.0F, 142.0F, 0.0F), _
                .PageNumber = 0, _
                .Type = AnnotationType.Point, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(pointAnnotation)

            ' Export annotation and save output file
            'ExEnd:AddPointAnnotation
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds text strikeout annotation in PDF document
    ''' </summary>
    Public Shared Sub AddTextStrikeOutAnnotation()
        Try
            'ExStart:AddTextStrikeOutAnnotation
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Text strikeout annotation
            Dim strikeoutAnnotation As New AnnotationInfo() With { _
                .Box = New Rectangle(CSng(101.76), CSng(688.73), CSng(321.85), 27), _
                .PageNumber = 1, _
                .SvgPath = "[{""x"":101.76,""y"":400.05},{""x"":255.9,""y"":400.05},{""x"":101.76,""y"":378.42},{""x"":255.91,""y"":378.42},{""x"":101.76,""y"":374.13},{""x"":423.61,""y"":374.13},{""x"":101.76,""y"":352.5},{""x"":423.61,""y"":352.5}]", _
                .Type = AnnotationType.TextStrikeout, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(strikeoutAnnotation)

            ' Export annotation and save output file
            'ExEnd:AddTextStrikeOutAnnotation
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds polyline annotation in PDF document
    ''' </summary>
    Public Shared Sub AddPolylineAnnotation()
        Try
            'ExStart:AddPolylineAnnotation
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Polyline annotation
            Dim polylineAnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 35.0), _
                .Box = New Rectangle(250.0F, 35.0F, 102.0F, 12.0F), _
                .PageNumber = 0, _
                .PenColor = 1201033, _
                .PenWidth = 2, _
                .SvgPath = "M250.8280751173709,48.209295774647885l0.6986854460093896,0l0.6986854460093896,-1.3973708920187793l0.6986854460093896,0l0.6986854460093896,-1.3973708920187793l1.3973708920187793,-0.6986854460093896l0.6986854460093896,-0.6986854460093896l0.6986854460093896,0l2.096056338028169,-1.3973708920187793l3.493427230046948,-1.3973708920187793l0.6986854460093896,-0.6986854460093896l1.3973708920187793,-1.3973708920187793l0.6986854460093896,0l1.3973708920187793,-0.6986854460093896l0.6986854460093896,0l0.6986854460093896,-0.6986854460093896l0.6986854460093896,0l0.6986854460093896,0l0,-0.6986854460093896l0.6986854460093896,0l0.6986854460093896,0l1.3973708920187793,0l0,-0.6986854460093896l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l2.096056338028169,-0.6986854460093896l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l1.3973708920187793,0l1.3973708920187793,0l1.3973708920187793,0l2.096056338028169,0l5.589483568075117,0l1.3973708920187793,0l2.096056338028169,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l1.3973708920187793,0l1.3973708920187793,0l0.6986854460093896,0.6986854460093896l1.3973708920187793,0l2.096056338028169,1.3973708920187793l0.6986854460093896,0l0.6986854460093896,0l0,0.6986854460093896l1.3973708920187793,0l0.6986854460093896,0.6986854460093896l1.3973708920187793,0.6986854460093896l0,0.6986854460093896l0.6986854460093896,0l1.3973708920187793,0.6986854460093896l1.3973708920187793,0.6986854460093896l3.493427230046948,0.6986854460093896l1.3973708920187793,0.6986854460093896l2.096056338028169,0.6986854460093896l1.3973708920187793,0.6986854460093896l1.3973708920187793,0l1.3973708920187793,0.6986854460093896l0.6986854460093896,0l0.6986854460093896,0.6986854460093896l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l2.7947417840375586,0l1.3973708920187793,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l2.7947417840375586,0l0.6986854460093896,0l2.7947417840375586,0l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,-0.6986854460093896l0.6986854460093896,0", _
                .Type = AnnotationType.Polyline, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(polylineAnnotation)

            ' Export annotation and save output file
            'ExEnd:AddPolylineAnnotation
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds text field annotation in PDF document
    ''' </summary>
    Public Shared Sub AddTextFieldAnnotation()
        Try
            'ExStart:AddTextFieldAnnotation
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Text field annotation
            Dim textFieldAnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 201.0), _
                .FieldText = "text in the box", _
                .FontFamily = "Arial", _
                .FontSize = 10, _
                .Box = New Rectangle(66.0F, 201.0F, 64.0F, 37.0F), _
                .PageNumber = 0, _
                .Type = AnnotationType.TextField, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(textFieldAnnotation)

            ' Export annotation and save output file
            'ExEnd:AddTextFieldAnnotation
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds watermark annotation in PDF document
    ''' </summary>
    Public Shared Sub AddWatermarkAnnotation()
        Try
            'ExStart:AddWatermarkAnnotation
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Watermark annotation
            Dim watermarkAnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(100.0, 300.0), _
                .FieldText = "TEXT STAMP", _
                .FontFamily = "Microsoft Sans Serif", _
                .FontSize = 10, _
                .FontColor = 2222222, _
                .Box = New Rectangle(430.0F, 272.0F, 66.0F, 51.0F), _
                .PageNumber = 0, _
                .Type = AnnotationType.Watermark, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(watermarkAnnotation)

            ' Export annotation and save output file
            'ExEnd:AddWatermarkAnnotation
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds text replacement annotation in PDF document
    ''' </summary>
    Public Shared Sub AddTextReplacementAnnotation()
        Try

            'ExStart:AddTextReplacementAnnotation
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Text replacement annotation
            Dim textReplacementAnnotation As New AnnotationInfo() With { _
                .Box = New Rectangle(CSng(101.76), CSng(826.73), CSng(229), 27), _
                .PageNumber = 1, _
                .SvgPath = "[{""x"":101.76,""y"":264.69},{""x"":331,""y"":264.69},{""x"":101.76,""y"":243.06},{""x"":331,""y"":243}]", _
                .Type = AnnotationType.TextReplacement, _
                .CreatorName = "Anonym A.", _
                .FieldText = "Replaced text", _
                .FontSize = 10 _
            }
            ' Add annotation to list
            annotations.Add(textReplacementAnnotation)

            ' Export annotation and save output file
            'ExEnd:AddTextReplacementAnnotation
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds arrow annotation in PDF document
    ''' </summary>
    Public Shared Sub AddArrowAnnotation()
        Try
            'ExStart:AddArrowAnnotation
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Arrow annotation
            Dim arrowAnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 252.0), _
                .Box = New Rectangle(279.4742F, 252.9241F, 129.9555F, -9.781596F), _
                .PageNumber = 0, _
                .PenColor = 1201033, _
                .PenStyle = 0, _
                .PenWidth = 1, _
                .SvgPath = "M279.47417840375584,252.92413145539905 L129.9554929577465,-9.781596244131455", _
                .Type = AnnotationType.Arrow, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(arrowAnnotation)

            ' Export annotation and save output file
            'ExEnd:AddArrowAnnotation
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds text redaction annotation in PDF document
    ''' </summary>
    Public Shared Sub AddTextRedactionAnnotation()
        Try
            'ExStart:AddTextRedactionAnnotation
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Text redaction annotation
            Dim textRedactionAnnotation As New AnnotationInfo() With { _
                .Box = New Rectangle(CSng(448.56), CSng(212.4), 210, 27), _
                .PageNumber = 0, _
                .SvgPath = "[{""x"":448.56,""y"":326.5},{""x"":658.7,""y"":326.5},{""x"":448.56,""y"":302.43},{""x"":658.7,""y"":302.43}]", _
                .Type = AnnotationType.TextRedaction, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(textRedactionAnnotation)

            ' Export annotation and save output file
            'ExEnd:AddTextRedactionAnnotation
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds underline annotation in PDF document
    ''' </summary>
    Public Shared Sub AddUnderLineAnnotation()
        Try
            'ExStart:AddUnderLineAnnotation
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Underline annotation
            Dim underlineAnnotation As New AnnotationInfo() With { _
                .Box = New Rectangle(CSng(248.57), CSng(1135.78), CSng(222.67), 27), _
                .PageNumber = 1, _
                .SvgPath = "[{""x"":248.57,""y"":503.507},{""x"":471,""y"":503.507},{""x"":248.57,""y"":468.9},{""x"":471,""y"":468.9}]", _
                .Type = AnnotationType.TextUnderline, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(underlineAnnotation)

            ' Export annotation and save output file
            'ExEnd:AddUnderLineAnnotation
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds distance annotation in PDF document
    ''' </summary>
    Public Shared Sub AddDistanceAnnotation()
        Try
            'ExStart:AddDistanceAnnotation
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Distance annotation
            Dim distanceAnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 287.0), _
                .Box = New Rectangle(248.0F, 287.0F, 115.0F, 25.0F), _
                .PageNumber = 0, _
                .PenColor = 1201033, _
                .PenStyle = 0, _
                .PenWidth = 1, _
                .SvgPath = "M248.73201877934272,295.5439436619718 l115.28309859154929,-4.192112676056338", _
                .Text = vbCr & vbLf & "Anonym A.: 115px", _
                .Type = AnnotationType.Distance, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(distanceAnnotation)

            ' Export annotation and save output file
            'ExEnd:AddDistanceAnnotation
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds resource redaction annotation in PDF document
    ''' </summary>
    Public Shared Sub AddResourceRedactionAnnotation()
        Try
            'ExStart:AddResourceRedactionAnnotation
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Resource redaction annotation
            Dim resourceRedactionAnnotation As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 271.78), _
                .BackgroundColor = 3355443, _
                .Box = New Rectangle(466.0F, 271.0F, 69.0F, 62.0F), _
                .PageNumber = 0, _
                .PenColor = 3355443, _
                .Type = AnnotationType.ResourcesRedaction, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(resourceRedactionAnnotation)

            ' Export annotation and save output file
            'ExEnd:AddResourceRedactionAnnotation
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Removes all annotations in PDF document
    ''' </summary>
    Public Shared Sub RemoveAllAnnotationsFromDocument()

        Try
            'ExStart:RemoveAllAnnotationsFromDocument
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Get output file stream
            Dim result As Stream = annotator.RemoveAnnotationStream(inputFile, DocumentType.Pdf)

            ' Save result stream to file.
            Using fileStream As New FileStream(CommonUtilities.MapDestinationFilePath("Annotated.pdf"), FileMode.Create)
                Dim buffer As Byte() = New Byte(result.Length - 1) {}
                result.Seek(0, SeekOrigin.Begin)
                result.Read(buffer, 0, buffer.Length)
                fileStream.Write(buffer, 0, buffer.Length)
                fileStream.Close()
                'ExEnd:RemoveAllAnnotationsFromDocument
            End Using
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''  For Words''''''''''''''''''''''''''''''''

    ''' <summary>
    ''' Adds text annotation in Words document
    ''' </summary>
    Public Shared Sub AddTextAnnotationforwords()
        Try
            'ExStart:AddTextAnnotationforwords
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Initialize text annotation.
            Dim textAnnotationforwords As New AnnotationInfo() With { _
                .Box = New Rectangle(CSng(265.44), CSng(153.86), 206, 36), _
                .PageNumber = 0, _
                .SvgPath = "[{""x"":265.44,""y"":388.83},{""x"":472.19,""y"":388.83},{""x"": 265.44,""y"":349.14},{""x"":472.19,""y"":349.14}]", _
                .Type = AnnotationType.Text, _
                .CreatorName = "Anonym A." _
            }

            ' Add annotation to list
            annotations.Add(textAnnotationforwords)

            ' Export annotation and save output file
            'ExEnd:AddTextAnnotationforwords
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub


    


    ''' <summary>
    ''' Adds area annotation with replies in Words document
    ''' </summary>
    Public Shared Sub AddAreaAnnotationWithRepliesforwords()
        Try
            'ExStart:AddAreaAnnotationWithRepliesforwords
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Area annotation with 2 replies
            Dim areaAnnnotationforwords As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 59.0), _
                .Replies = New AnnotationReplyInfo() {New AnnotationReplyInfo() With { _
                    .Message = "Hello!", _
                    .RepliedOn = DateTime.Now, _
                    .UserName = "John" _
                }, New AnnotationReplyInfo() With { _
                    .Message = "Hi!", _
                    .RepliedOn = DateTime.Now, _
                    .UserName = "Judy" _
                }}, _
                .BackgroundColor = 11111111, _
                .Box = New Rectangle(300.0F, 200.0F, 88.0F, 37.0F), _
                .PageNumber = 0, _
                .PenColor = 2222222, _
                .PenStyle = 1, _
                .PenWidth = 1, _
                .Type = AnnotationType.Area, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(areaAnnnotationforwords)

            ' Export annotation and save output file
            'ExEnd:AddAreaAnnotationWithRepliesforwords
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds point annotation in Words document
    ''' </summary>
    Public Shared Sub AddPointAnnotationforwords()
        Try
            'ExStart:AddPointAnnotationforwords
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)
            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Point annotation
            Dim pointAnnotationforwords As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 81.0), _
                .Box = New Rectangle(212.0F, 81.0F, 142.0F, 0.0F), _
                .PageNumber = 0, _
                .Type = AnnotationType.Point, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(pointAnnotationforwords)

            ' Export annotation and save output file
            'ExEnd:AddPointAnnotationforwords
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds text strikeout annotation in Words document
    ''' </summary>
    Public Shared Sub AddTextStrikeOutAnnotationforwords()
        Try
            'ExStart:AddTextStrikeOutAnnotationforwords
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Text strikeout annotationforwords
            Dim strikeoutAnnotationforwords As New AnnotationInfo() With { _
                .Box = New Rectangle(CSng(101.76), CSng(688.73), CSng(321.85), 27), _
                .PageNumber = 1, _
                .SvgPath = "[{""x"":101.76,""y"":400.05},{""x"":255.9,""y"":400.05},{""x"":101.76,""y"":378.42},{""x"":255.91,""y"":378.42},{""x"":101.76,""y"":374.13},{""x"":423.61,""y"":374.13},{""x"":101.76,""y"":352.5},{""x"":423.61,""y"":352.5}]", _
                .Type = AnnotationType.TextStrikeout, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(strikeoutAnnotationforwords)

            ' Export annotation and save output file
            'ExEnd:AddTextStrikeOutAnnotationforwords
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds polyline annotation in Words document
    ''' </summary>
    Public Shared Sub AddPolylineAnnotationforwords()
        Try
            'ExStart:AddPolylineAnnotationforwords
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Polyline annotation
            Dim polylineAnnotationforwords As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 35.0), _
                .Box = New Rectangle(250.0F, 35.0F, 102.0F, 12.0F), _
                .PageNumber = 0, _
                .PenColor = 1201033, _
                .PenWidth = 2, _
                .SvgPath = "M250.8280751173709,48.209295774647885l0.6986854460093896,0l0.6986854460093896,-1.3973708920187793l0.6986854460093896,0l0.6986854460093896,-1.3973708920187793l1.3973708920187793,-0.6986854460093896l0.6986854460093896,-0.6986854460093896l0.6986854460093896,0l2.096056338028169,-1.3973708920187793l3.493427230046948,-1.3973708920187793l0.6986854460093896,-0.6986854460093896l1.3973708920187793,-1.3973708920187793l0.6986854460093896,0l1.3973708920187793,-0.6986854460093896l0.6986854460093896,0l0.6986854460093896,-0.6986854460093896l0.6986854460093896,0l0.6986854460093896,0l0,-0.6986854460093896l0.6986854460093896,0l0.6986854460093896,0l1.3973708920187793,0l0,-0.6986854460093896l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l2.096056338028169,-0.6986854460093896l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l1.3973708920187793,0l1.3973708920187793,0l1.3973708920187793,0l2.096056338028169,0l5.589483568075117,0l1.3973708920187793,0l2.096056338028169,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l1.3973708920187793,0l1.3973708920187793,0l0.6986854460093896,0.6986854460093896l1.3973708920187793,0l2.096056338028169,1.3973708920187793l0.6986854460093896,0l0.6986854460093896,0l0,0.6986854460093896l1.3973708920187793,0l0.6986854460093896,0.6986854460093896l1.3973708920187793,0.6986854460093896l0,0.6986854460093896l0.6986854460093896,0l1.3973708920187793,0.6986854460093896l1.3973708920187793,0.6986854460093896l3.493427230046948,0.6986854460093896l1.3973708920187793,0.6986854460093896l2.096056338028169,0.6986854460093896l1.3973708920187793,0.6986854460093896l1.3973708920187793,0l1.3973708920187793,0.6986854460093896l0.6986854460093896,0l0.6986854460093896,0.6986854460093896l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l2.7947417840375586,0l1.3973708920187793,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l1.3973708920187793,0l0.6986854460093896,0l2.7947417840375586,0l0.6986854460093896,0l2.7947417840375586,0l1.3973708920187793,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,0l0.6986854460093896,-0.6986854460093896l0.6986854460093896,0", _
                .Type = AnnotationType.Polyline, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(polylineAnnotationforwords)

            ' Export annotation and save output file
            'ExEnd:AddPolylineAnnotationforwords
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds text field annotation in Words document
    ''' </summary>
    Public Shared Sub AddTextFieldAnnotationforwords()
        Try
            'ExStart:AddTextFieldAnnotationforwords
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Text field annotation
            Dim textFieldAnnotationforwords As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 201.0), _
                .FieldText = "text in the box", _
                .FontFamily = "Arial", _
                .FontSize = 10, _
                .Box = New Rectangle(66.0F, 201.0F, 64.0F, 37.0F), _
                .PageNumber = 0, _
                .Type = AnnotationType.TextField, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(textFieldAnnotationforwords)

            ' Export annotation and save output file
            'ExEnd:AddTextFieldAnnotationforwords
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds watermark annotation in Words document
    ''' </summary>
    Public Shared Sub AddWatermarkAnnotationforwords()
        Try
            'ExStart:AddWatermarkAnnotationforwords
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Watermark annotation
            Dim watermarkAnnotationforwords As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(100.0, 300.0), _
                .FieldText = "TEXT STAMP", _
                .FontFamily = "Microsoft Sans Serif", _
                .FontSize = 10, _
                .FontColor = 2222222, _
                .Box = New Rectangle(430.0F, 272.0F, 66.0F, 51.0F), _
                .PageNumber = 0, _
                .Type = AnnotationType.Watermark, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(watermarkAnnotationforwords)

            ' Export annotation and save output file
            'ExEnd:AddWatermarkAnnotationforwords
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds text replacement annotation in Words document
    ''' </summary>
    Public Shared Sub AddTextReplacementAnnotationforwords()
        Try

            'ExStart:AddTextReplacementAnnotationforwords
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Text replacement annotation
            Dim textReplacementAnnotationforwords As New AnnotationInfo() With { _
                .Box = New Rectangle(CSng(101.76), CSng(826.73), CSng(229), 27), _
                .PageNumber = 1, _
                .SvgPath = "[{""x"":101.76,""y"":264.69},{""x"":331,""y"":264.69},{""x"":101.76,""y"":243.06},{""x"":331,""y"":243}]", _
                .Type = AnnotationType.TextReplacement, _
                .CreatorName = "Anonym A.", _
                .FieldText = "Replaced text", _
                .FontSize = 10 _
            }
            ' Add annotation to list
            annotations.Add(textReplacementAnnotationforwords)

            ' Export annotation and save output file
            'ExEnd:AddTextReplacementAnnotationforwords
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Pdf)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds arrow annotation in Words document
    ''' </summary>
    Public Shared Sub AddArrowAnnotationforwords()
        Try
            'ExStart:AddArrowAnnotationforwords
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Arrow annotation
            Dim arrowAnnotationforwords As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 252.0), _
                .Box = New Rectangle(279.4742F, 252.9241F, 129.9555F, -9.781596F), _
                .PageNumber = 0, _
                .PenColor = 1201033, _
                .PenStyle = 0, _
                .PenWidth = 1, _
                .SvgPath = "M279.47417840375584,252.92413145539905 L129.9554929577465,-9.781596244131455", _
                .Type = AnnotationType.Arrow, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(arrowAnnotationforwords)

            ' Export annotation and save output file
            'ExEnd:AddArrowAnnotation
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds text redaction annotation in Words document
    ''' </summary>
    Public Shared Sub AddTextRedactionAnnotationforwords()
        Try
            'ExStart:AddTextRedactionAnnotationforwords
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Text redaction annotation
            Dim textRedactionAnnotationforwords As New AnnotationInfo() With { _
                .Box = New Rectangle(CSng(448.56), CSng(212.4), 210, 27), _
                .PageNumber = 0, _
                .SvgPath = "[{""x"":448.56,""y"":326.5},{""x"":658.7,""y"":326.5},{""x"":448.56,""y"":302.43},{""x"":658.7,""y"":302.43}]", _
                .Type = AnnotationType.TextRedaction, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(textRedactionAnnotationforwords)

            ' Export annotation and save output file
            'ExEnd:AddTextRedactionAnnotationforwords
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds underline annotation in Words document
    ''' </summary>
    Public Shared Sub AddUnderLineAnnotationforwords()
        Try
            'ExStart:AddUnderLineAnnotationforwords
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Underline annotation
            Dim underlineAnnotationforwords As New AnnotationInfo() With { _
                .Box = New Rectangle(CSng(248.57), CSng(1135.78), CSng(222.67), 27), _
                .PageNumber = 1, _
                .SvgPath = "[{""x"":248.57,""y"":503.507},{""x"":471,""y"":503.507},{""x"":248.57,""y"":468.9},{""x"":471,""y"":468.9}]", _
                .Type = AnnotationType.TextUnderline, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(underlineAnnotationforwords)

            ' Export annotation and save output file
            'ExEnd:AddUnderLineAnnotationforwords
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds distance annotation in Words document
    ''' </summary>
    Public Shared Sub AddDistanceAnnotationforwords()
        Try
            'ExStart:AddDistanceAnnotation
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Distance annotation
            Dim distanceAnnotationforwords As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 287.0), _
                .Box = New Rectangle(248.0F, 287.0F, 115.0F, 25.0F), _
                .PageNumber = 0, _
                .PenColor = 1201033, _
                .PenStyle = 0, _
                .PenWidth = 1, _
                .SvgPath = "M248.73201877934272,295.5439436619718 l115.28309859154929,-4.192112676056338", _
                .Text = vbCr & vbLf & "Anonym A.: 115px", _
                .Type = AnnotationType.Distance, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(distanceAnnotationforwords)

            ' Export annotation and save output file
            'ExEnd:AddDistanceAnnotationforwords
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Adds resource redaction annotation in PDF document
    ''' </summary>
    Public Shared Sub AddResourceRedactionAnnotationforwords()
        Try
            'ExStart:AddResourceRedactionAnnotationforwords
            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Initialize list of AnnotationInfo
            Dim annotations As New List(Of AnnotationInfo)()

            ' Resource redaction annotation
            Dim resourceRedactionAnnotationforwords As New AnnotationInfo() With { _
                .AnnotationPosition = New Point(852.0, 271.78), _
                .BackgroundColor = 3355443, _
                .Box = New Rectangle(466.0F, 271.0F, 69.0F, 62.0F), _
                .PageNumber = 0, _
                .PenColor = 3355443, _
                .Type = AnnotationType.ResourcesRedaction, _
                .CreatorName = "Anonym A." _
            }
            ' Add annotation to list
            annotations.Add(resourceRedactionAnnotationforwords)

            ' Export annotation and save output file
            'ExEnd:AddResourceRedactionAnnotationforwords
            CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words)
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Removes all annotations in Words document
    ''' </summary>
    Public Shared Sub RemoveAllAnnotationsFromDocumentforwords()

        Try
            'ExStart:RemoveAllAnnotationsFromWordsDocument
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            ' Get output file stream
            Dim result As Stream = annotator.RemoveAnnotationStream(inputFile, DocumentType.Words)

            ' Save result stream to file.
            Using fileStream As New FileStream(CommonUtilities.MapDestinationFilePath("Annotated.docx"), FileMode.Create)
                Dim buffer As Byte() = New Byte(result.Length - 1) {}
                result.Seek(0, SeekOrigin.Begin)
                result.Read(buffer, 0, buffer.Length)
                fileStream.Write(buffer, 0, buffer.Length)
                fileStream.Close()
                'ExEnd:RemoveAllAnnotationsFromWordsDocument
            End Using
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub


    ''' <summary>
    ''' Import and Export Annotations from Words document.
    ''' </summary>
    ''' Update filePath with path to word document files before using this function
    Public Shared Sub ImportAndExportAnnotationsFromWords()
        Try
            'ExStart:ImportAndExportAnnotationsFromWords
            ' Create instance of annotator. 
            Dim cfg As AnnotationConfig = CommonUtilities.GetConfiguration()

            Dim annotator As New AnnotationImageHandler(cfg)

            ' Get input file stream
            Dim inputFile As Stream = New FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite)

            'importing annotations from Words document
            Dim annotations As AnnotationInfo() = annotator.ImportAnnotations(inputFile, DocumentType.Words)

            'export imported annotation to another document (just for check)
            Dim clearDocument As Stream = New FileStream(CommonUtilities.MapDestinationFilePath("Clear.docx"), FileMode.Open, FileAccess.ReadWrite)
            Dim output As Stream = annotator.ExportAnnotationsToDocument(clearDocument, annotations.ToList(), DocumentType.Words)


            ' Export annotation and save output file
            'save results after export
            Using fileStream As New FileStream(CommonUtilities.MapDestinationFilePath("AnnotationImportAndExportAnnotated.docx"), FileMode.Create)
                Dim buffer As Byte() = New Byte(output.Length - 1) {}
                output.Seek(0L, SeekOrigin.Begin)
                output.Read(buffer, 0, buffer.Length)
                fileStream.Write(buffer, 0, buffer.Length)
                fileStream.Close()
            End Using
            'ExEnd:ImportAndExportAnnotationsFromWords
        Catch exp As System.Exception
            Console.WriteLine(exp.Message)
        End Try
    End Sub



End Class
'ExEnd:AllAnnotations 