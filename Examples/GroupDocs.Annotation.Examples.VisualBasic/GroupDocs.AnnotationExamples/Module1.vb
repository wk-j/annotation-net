Module Module1

    Sub Main()
        ' Apply product license
        '             * Uncomment following function if you have product license
        '             * 

        'CommonUtilities.ApplyLicense()


        '....................for PDF Document..............................

        ''Add text annotation
        'Annotations.AddTextAnnotation()

        ''Add area annotation with replies 
        'Annotations.AddAreaAnnotationWithReplies()

        ''Add point annotation
        'Annotations.AddPointAnnotation()

        ''Add text strike out annotation
        'Annotations.AddTextStrikeOutAnnotation()

        ''Add polyline annotation
        'Annotations.AddPolylineAnnotation()

        ''Add text field annotation
        'Annotations.AddTextFieldAnnotation()

        ''Add watermark annotation
        'Annotations.AddWatermarkAnnotation()

        ''Add text replacement annotation
        'Annotations.AddTextReplacementAnnotation()

        ''Add arrow annotation
        'Annotations.AddArrowAnnotation()

        ''Add text redaction annotation
        'Annotations.AddTextRedactionAnnotation()

        ''Import and Export Annotations from Words document.
        Annotations.ImportAndExportAnnotationsFromWords()

        ''Add underline annotation
        'Annotations.AddUnderLineAnnotation()

        ''Add distance annotation
        'Annotations.AddDistanceAnnotation()

        ''Add resource redaction annotation
        'Annotations.AddResourceRedactionAnnotation()

        ''Remove all annotations
        'Annotations.RemoveAllAnnotationsFromDocument()



        '....................for Words Document..............................


        ' ''Add text annotation
        'Annotations.AddTextAnnotationforwords()


        ' ''Add area annotation with replies 
        'Annotations.AddAreaAnnotationWithRepliesforwords()

        ' ''Add point annotation
        'Annotations.AddPointAnnotationforwords()

        ' ''Add text strike out annotation
        'Annotations.AddTextStrikeOutAnnotationforwords()

        ' ''Add polyline annotation
        'Annotations.AddPolylineAnnotationforwords()

        ' ''Add text field annotation
        'Annotations.AddTextFieldAnnotationforwords()

        ' ''Add watermark annotation
        'Annotations.AddWatermarkAnnotation()

        ' ''Add text replacement annotation
        'Annotations.AddTextReplacementAnnotationforwords()

        ' ''Add arrow annotation
        'Annotations.AddArrowAnnotationforwords()

        ' ''Add text redaction annotation
        'Annotations.AddTextRedactionAnnotationforwords()

        ' ''Add underline annotation
        'Annotations.AddUnderLineAnnotationforwords()

        ' ''Add distance annotation
        'Annotations.AddDistanceAnnotationforwords()

        ' ''Add resource redaction annotation
        'Annotations.AddResourceRedactionAnnotationforwords()

        ' ''Remove all annotations
        'Annotations.RemoveAllAnnotationsFromDocumentforwords()


        '.......................... for Slides....................

        ''Add text annotation in Slides
        'Annotations.AddTextAnnotationSlides()

        
        ''Add area annotation with replies in Slides
        'Annotations.AddAreaAnnotationWithRepliesSlides()

        ''Add point annotation in Slides
        'Annotations.AddPointAnnotationSlides()

        ''Add text strike out annotation in Slides
        'Annotations.AddTextStrikeOutAnnotationSlides()

        'Add polyline annotation in Slides
        'Annotations.AddPolylineAnnotationSlides()

        ''Add text field annotation in Slides
        'Annotations.AddTextFieldAnnotationSlides()

        ''Add watermark annotation in Slides
        'Annotations.AddWatermarkAnnotationSlides()

        ''Add text replacement annotation in Slides
        'Annotations.AddTextReplacementAnnotationSlides()

        ''Add arrow annotation in Slides
        'Annotations.AddArrowAnnotationSlides()

        ''Add text redaction annotation in Slides
        'Annotations.AddTextRedactionAnnotationSlides()

        ''Add underline annotation in Slides
        'Annotations.AddUnderLineAnnotationSlides()

        ''Add distance annotation in Slides
        'Annotations.AddDistanceAnnotationSlides()

        ''Add resource redaction annotation in Slides
        ' Annotations.AddResourceRedactionAnnotationSlides()

        ''Remove all annotations in Slides
        'Annotations.RemoveAllAnnotationsFromDocumentSlides()


        '....................for Cells Document..............................

        ''Add text annotation in cells
        'Annotations.AddTextAnnotationInCells()



        '.........................DataStorage Functions.................................

        'Create document
        'DataStorage.CreateDocument()

        ''Assign access rights
        'DataStorage.AssignAccessRights()

        ''Create and get annotation
        'DataStorage.CreateAndGetAnnotation()

        ''Get all annotation of a document
        'DataStorage.GetAllDocumentAnnotation()

        ''Resize annotation 
        'DataStorage.ResizeAnnotationResult()

        ''Move an anotation 
        'DataStorage.MoveAnnotationResult()

        ''Set background color
        'DataStorage.SetBackgroundColorResult()

        ''Edit annotation
        'DataStorage.EditTextFieldAnnotation()

        ''Remove annotation
        'DataStorage.RemoveAnnotation()

        ''Add annotation reply
        'DataStorage.AddAnnotationReply()

        ''Add document collaborator
        'DataStorage.AddCollaborator()

        ''Get document collaborator
        'DataStorage.GetCollaborator()

        ''Update document collaborator
        'DataStorage.UpdateCollaborator()

        ''Delete document collaborator
        'DataStorage.DeleteCollaborator()

        ''Delete document collaborator
        'DataStorage.ManageCollaboratorRights()

        ''Export annotation to document
        'DataStorage.ExportAnnotationInFile()


        '......................... Other Operations.............................

        ''Get image representation of the document
        'CommonUtilities.GetImageRepresentation("sample.pdf");

        ''Get text coordinates in image representation of the document
        'CommonUtilities.GetTextCoordinates("sample.pdf");
        '#End Region

        Console.ReadKey()
    End Sub

End Module
