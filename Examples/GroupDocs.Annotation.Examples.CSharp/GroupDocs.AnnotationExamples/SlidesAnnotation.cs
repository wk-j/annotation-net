using GroupDocs.Annotation.Config;
using GroupDocs.Annotation.Domain;
using GroupDocs.Annotation.Handler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Annotation.CSharp
{
    class SlidesAnnotation
    { 
        // initialize file path
        //ExStart:SourceDocFilePath
        private const string filePath = "Annotated.pptx";
        //ExEnd:SourceDocFilePath



        /// <summary>
        /// Add text annotation in slides
        /// </summary>
        /// Update filePath with path to Slides file before using this function
        public static void AddTextAnnotationInSlides()
        {
            try
            {
                //ExStart:AddTextAnnotationInSlides
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Initialize text annotation.
                AnnotationInfo textAnnotation = new AnnotationInfo
                {
                    PageNumber = 0,
                    AnnotationPosition = new Point(1, 2),
                    FieldText = "Hello!",
                    CreatorName = "John"
                };

                // Add annotation to list
                annotations.Add(textAnnotation);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Slides);
                //ExEnd:AddTextAnnotationInSlides
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
