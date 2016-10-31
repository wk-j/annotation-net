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
            
        CommonUtilities.StorageFolderPath = "../../../../Data/Samples/";
        CommonUtilities.DestinationFolderPath = "../../../../Data/Output/";
        CommonUtilities.LicenseFilePath = "D://License/Groupdocs.Total.lic";
        CommonUtilities.filePath = "Annotated.pdf";

            /* Apply product license
             * Uncomment following function if you have product license
             * */

            CommonUtilities.ApplyLicense();

            #region Annotation Functions for PDF

            CommonUtilities.filePath = "Annotated.pdf";

            ////Add text annotation
            //  PDFAnnotation.AddTextAnnotation();

            //Add text annotation in cells
            //PDFAnnotation.AddTextAnnotationInCells();

            //Add text annotation in slides
            //PDFAnnotation.AddTextAnnotationInSlides();

            ////Add area annotation with replies 
            //PDFAnnotation.AddAreaAnnotationWithReplies();

            ////Add point annotation
            // PDFAnnotation.AddPointAnnotation();

            ////Add text strike out annotation
            //PDFAnnotation.AddTextStrikeOutAnnotation();

            ////Add polyline annotation
            //PDFAnnotation.AddPolylineAnnotation();

            ////Add text field annotation
            ////PDFAnnotation.AddTextFieldAnnotation();

            ////Add watermark annotation
            //PDFAnnotation.AddWatermarkAnnotation();

            ////Add text replacement annotation
            //PDFAnnotation.AddTextReplacementAnnotation();

            ////Add arrow annotation
            //PDFAnnotation.AddArrowAnnotation();

            ////Add text redaction annotation
            // PDFAnnotation.AddTextRedactionAnnotation();

            ////Add underline annotation
            //PDFAnnotation.AddUnderLineAnnotation();

            ////Add distance annotation
            //PDFAnnotation.AddDistanceAnnotation();

            ////Add resource redaction annotation
            // PDFAnnotation.AddResourceRedactionAnnotation();

            ////Remove all annotations
            // PDFAnnotation.RemoveAllAnnotationsFromDocument();

            #endregion

            #region Annotation Functions for Words Document format


            CommonUtilities.filePath = "Annotated.docx";

            ////Add area annotation with replies  for Words Document format
            // WordAnnotation.AddAreaAnnotationWithRepliesforWords();

            ////Add point annotation for Words Document format
            // WordAnnotation.AddPointAnnotation();

            ////Add text strike out annotation for Words Document format
            //WordAnnotation.AddTextStrikeOutAnnotationforWords();


            ////Add text field annotation for Words Document format
            //WordAnnotation.AddTextFieldAnnotationforWords();

            ////Add text replacement annotation for Words Document format
            //WordAnnotation.AddTextReplacementAnnotationforWords();

            ////Add arrow annotation for Words Document format
            //WordAnnotation.AddArrowAnnotationforWords();

            ////Add text redaction annotation for Words Document format
            // WordAnnotation.AddTextRedactionAnnotationforWords();

            ////Add underline annotation for Words Document format
            //WordAnnotation.AddUnderLineAnnotationforWords();


            ////Add resource redaction annotation for Words Document format
            // WordAnnotation.AddResourceRedactionAnnotationforWords();

            ////Import and Export Annotations from Words document.
            WordAnnotation.ImportAndExportAnnotationsFromWords();

            #endregion

            #region Slides

            CommonUtilities.filePath = "Annotated.pptx";
            //Add text annotation in slides
            //SlidesAnnotations.AddTextAnnotationInSlides();
            #endregion

            #region Cells
            CommonUtilities.filePath = "Annotated.xlsx";
            //Add text annotation in Cells
            //CellsAnnotation.AddTextAnnotationInCells();
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
