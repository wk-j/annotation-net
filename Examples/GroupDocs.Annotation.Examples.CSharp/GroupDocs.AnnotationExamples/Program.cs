using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupDocs.Data.Json;
using GroupDocs.Data.Json.Repositories;
using System.IO;

namespace GroupDocs.Annotation.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Apply product license
             * Uncomment following function if you have product license
             * */
            CommonUtilities.ApplyLicense();

            #region Annotation Functions for PDF

            ////Add text annotation
            //  Annotations.AddTextAnnotation();

            //Add text annotation in cells
            //Annotations.AddTextAnnotationInCells();

            //Add text annotation in slides
            //Annotations.AddTextAnnotationInSlides();

            ////Add area annotation with replies 
            //Annotations.AddAreaAnnotationWithReplies();

            ////Add point annotation
            // Annotations.AddPointAnnotation();

            ////Add text strike out annotation
            //Annotations.AddTextStrikeOutAnnotation();

            ////Add polyline annotation
            //Annotations.AddPolylineAnnotation();

            ////Add text field annotation
            ////Annotations.AddTextFieldAnnotation();

            ////Add watermark annotation
            //Annotations.AddWatermarkAnnotation();

            ////Add text replacement annotation
            //Annotations.AddTextReplacementAnnotation();

            ////Add arrow annotation
            //Annotations.AddArrowAnnotation();

            ////Add text redaction annotation
            // Annotations.AddTextRedactionAnnotation();

            ////Add underline annotation
            //Annotations.AddUnderLineAnnotation();

            ////Add distance annotation
            //Annotations.AddDistanceAnnotation();

            ////Add resource redaction annotation
            // Annotations.AddResourceRedactionAnnotation();

            ////Remove all annotations
            // Annotations.RemoveAllAnnotationsFromDocument();

            #endregion

            #region Annotation Functions for Words Document format


            ////Add area annotation with replies  for Words Document format
            // Annotations.AddAreaAnnotationWithRepliesforWords();

            ////Add point annotation for Words Document format
            // Annotations.AddPointAnnotation();

            ////Add text strike out annotation for Words Document format
            //Annotations.AddTextStrikeOutAnnotationforWords();


            ////Add text field annotation for Words Document format
            //Annotations.AddTextFieldAnnotationforWords();

            ////Add text replacement annotation for Words Document format
            //Annotations.AddTextReplacementAnnotationforWords();

            ////Add arrow annotation for Words Document format
            //Annotations.AddArrowAnnotationforWords();

            ////Add text redaction annotation for Words Document format
            // Annotations.AddTextRedactionAnnotationforWords();

            ////Add underline annotation for Words Document format
            //Annotations.AddUnderLineAnnotationforWords();


            ////Add resource redaction annotation for Words Document format
            // Annotations.AddResourceRedactionAnnotationforWords();

            ////Import and Export Annotations from Words document.
            Annotations.ImportAndExportAnnotationsFromWords();

            #endregion

            #region Cells & Slides
            //Add text annotation in cells
            //Annotations.AddTextAnnotationInCells();

            //Add text annotation in slides
            //Annotations.AddTextAnnotationInSlides();
            #endregion


            #region DataStorage Functions

            //Create document
            //DataStorage.CreateDocument();

            ////Assign access rights
            //DataStorage.AssignAccessRights();

            ////Create and get annotation
            //DataStorage.CreateAndGetAnnotation();

            ////Get all annotation of a document
            //DataStorage.GetAllDocumentAnnotation();

            ////Resize annotation 
            //DataStorage.ResizeAnnotationResult();

            ////Move an anotation 
            //DataStorage.MoveAnnotationResult();

            ////Set background color
            //DataStorage.SetBackgroundColorResult();

            ////Edit annotation
            //DataStorage.EditTextFieldAnnotation();

            ////Remove annotation
            //DataStorage.RemoveAnnotation();

            ////Add annotation reply
            //DataStorage.AddAnnotationReply();

            ////Add document collaborator
            //DataStorage.AddCollaborator();

            ////Get document collaborator
            //DataStorage.GetCollaborator();

            ////Update document collaborator
            //DataStorage.UpdateCollaborator();

            ////Delete document collaborator
            //DataStorage.DeleteCollaborator();

            ////Delete document collaborator
            //DataStorage.ManageCollaboratorRights();

            ////Export annotation to document
            //DataStorage.ExportAnnotationInFile();

            #endregion

            #region Other Operations

            ////Get image representation of the document
            //CommonUtilities.GetImageRepresentation("sample.pdf");

            ////Get text coordinates in image representation of the document
            //CommonUtilities.GetTextCoordinates("sample.pdf");
            #endregion
            Console.ReadKey();

        }


    }
}
