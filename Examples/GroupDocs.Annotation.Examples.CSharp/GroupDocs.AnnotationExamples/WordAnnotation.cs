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
      
    class WordAnnotation
    {

        // initialize file path
        //ExStart:SourceDocFilePath
        private const string filePath = "Annotated.docx";
        //ExEnd:SourceDocFilePath
        public static void AddTextAnnotationforWords()
        {
            try
            {
                //ExStart:AddTextAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Initialize text annotation.
                AnnotationInfo textAnnotationforWords = new AnnotationInfo
                {
                    Box = new Rectangle((float)265.44, (float)153.86, 206, 36),
                    PageNumber = 0,
                    SvgPath = "[{\"x\":265.44,\"y\":388.83},{\"x\":472.19,\"y\":388.83},{\"x\": 265.44,\"y\":349.14},{\"x\":472.19,\"y\":349.14}]",
                    Type = AnnotationType.Text,
                    CreatorName = "Anonym A."
                };

                // Add annotation to list
                annotations.Add(textAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddTextAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }


        /// <summary>
        /// Adds area annotation with replies in words document
        /// </summary>
        public static void AddAreaAnnotationWithRepliesforWords()
        {
            try
            {
                //ExStart:AddAreaAnnotationWithRepliesforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Area annotation with 2 replies
                AnnotationInfo areaAnnnotationforWords = new AnnotationInfo()
                {
                    AnnotationPosition = new Point(852.0, 59.0),
                    Replies = new AnnotationReplyInfo[]
                {
                    new AnnotationReplyInfo
                    {
                        Message = "Hello!",
                        RepliedOn = DateTime.Now,
                        UserName = "John"
                    },
                    new AnnotationReplyInfo
                    {
                        Message = "Hi!",
                        RepliedOn = DateTime.Now,
                        UserName = "Judy"
                    }
                },
                    BackgroundColor = 11111111,
                    Box = new Rectangle(300f, 200f, 88f, 37f),
                    PageNumber = 0,
                    PenColor = 2222222,
                    PenStyle = 1,
                    PenWidth = 1,
                    Type = AnnotationType.Area,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(areaAnnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddAreaAnnotationWithRepliesforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds point annotation in words document
        /// </summary>
        public static void AddPointAnnotationforWords()
        {
            try
            {
                //ExStart:AddPointAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);
                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Point annotation
                AnnotationInfo pointAnnotationforWords = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 81.0),
                    Box = new Rectangle(212f, 81f, 142f, 0.0f),
                    PageNumber = 0,
                    Type = AnnotationType.Point,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(pointAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddPointAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds text strikeout annotation in words document
        /// </summary>
        public static void AddTextStrikeOutAnnotationforWords()
        {
            try
            {
                //ExStart:AddTextStrikeOutAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Text strikeout annotation
                AnnotationInfo strikeoutAnnotationforWords = new AnnotationInfo
                {
                    Box = new Rectangle((float)101.76, (float)688.73, (float)321.85, 27),
                    PageNumber = 1,
                    SvgPath = "[{\"x\":101.76,\"y\":400.05},{\"x\":255.9,\"y\":400.05},{\"x\":101.76,\"y\":378.42},{\"x\":255.91,\"y\":378.42},{\"x\":101.76,\"y\":374.13},{\"x\":423.61,\"y\":374.13},{\"x\":101.76,\"y\":352.5},{\"x\":423.61,\"y\":352.5}]",
                    Type = AnnotationType.TextStrikeout,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(strikeoutAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddTextStrikeOutAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds polyline annotation in words document
        /// </summary>

        /// <summary>
        /// Adds text field annotation in words document
        /// </summary>
        public static void AddTextFieldAnnotationforWords()
        {
            try
            {
                //ExStart:AddTextFieldAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Text field annotation
                AnnotationInfo textFieldAnnotationforWords = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 201.0),
                    FieldText = "text in the box",
                    FontFamily = "Arial",
                    FontSize = 10,
                    Box = new Rectangle(66f, 201f, 64f, 37f),
                    PageNumber = 0,
                    Type = AnnotationType.TextField,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(textFieldAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddTextFieldAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds watermark annotation in words document
        /// </summary>

        /// <summary>
        /// Adds text replacement annotation in words document
        /// </summary>
        public static void AddTextReplacementAnnotationforWords()
        {
            try
            {

                //ExStart:AddTextReplacementAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Text replacement annotation
                AnnotationInfo textReplacementAnnotationforWords = new AnnotationInfo
                {
                    Box = new Rectangle((float)101.76, (float)826.73, (float)229, 27),
                    PageNumber = 1,
                    SvgPath = "[{\"x\":101.76,\"y\":264.69},{\"x\":331,\"y\":264.69},{\"x\":101.76,\"y\":243.06},{\"x\":331,\"y\":243}]",
                    Type = AnnotationType.TextReplacement,
                    CreatorName = "Anonym A.",
                    FieldText = "Replaced text",
                    FontSize = 10
                };
                // Add annotation to list
                annotations.Add(textReplacementAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddTextReplacementAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds arrow annotation in words document
        /// </summary>
        public static void AddArrowAnnotationforWords()
        {
            try
            {
                //ExStart:AddArrowAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Arrow annotation
                AnnotationInfo arrowAnnotationforWords = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 252.0),
                    Box = new Rectangle(279.4742f, 252.9241f, 129.9555f, -9.781596f),
                    PageNumber = 0,
                    PenColor = 1201033,
                    PenStyle = 0,
                    PenWidth = 1,
                    SvgPath = "M279.47417840375584,252.92413145539905 L129.9554929577465,-9.781596244131455",
                    Type = AnnotationType.Arrow,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(arrowAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddArrowAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds text redaction annotation in words document
        /// </summary>
        public static void AddTextRedactionAnnotationforWords()
        {
            try
            {
                //ExStart:AddTextRedactionAnnotationforWords
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Text redaction annotation
                AnnotationInfo textRedactionAnnotationforWords = new AnnotationInfo
                {
                    Box = new Rectangle((float)448.56, (float)212.4, 210, 27),
                    PageNumber = 0,
                    SvgPath = "[{\"x\":448.56,\"y\":326.5},{\"x\":658.7,\"y\":326.5},{\"x\":448.56,\"y\":302.43},{\"x\":658.7,\"y\":302.43}]",
                    Type = AnnotationType.TextRedaction,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(textRedactionAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddTextRedactionAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds underline annotation in words document
        /// </summary>
        public static void AddUnderLineAnnotationforWords()
        {
            try
            {
                //ExStart:AddUnderLineAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Underline annotation
                AnnotationInfo underlineAnnotationforWords = new AnnotationInfo
                {
                    Box = new Rectangle((float)248.57, (float)1135.78, (float)222.67, 27),
                    PageNumber = 1,
                    SvgPath = "[{\"x\":248.57,\"y\":503.507},{\"x\":471,\"y\":503.507},{\"x\":248.57,\"y\":468.9},{\"x\":471,\"y\":468.9}]",
                    Type = AnnotationType.TextUnderline,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(underlineAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddUnderLineAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds distance annotation in words document
        /// </summary>


        /// <summary>
        /// Adds resource redaction annotation in words document
        /// </summary>
        public static void AddResourceRedactionAnnotationforWords()
        {
            try
            {
                //ExStart:AddResourceRedactionAnnotation
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Resource redaction annotation
                AnnotationInfo resourceRedactionAnnotationforWords = new AnnotationInfo
                {
                    AnnotationPosition = new Point(852.0, 271.78),
                    BackgroundColor = 3355443,
                    Box = new Rectangle(466f, 271f, 69f, 62f),
                    PageNumber = 0,
                    PenColor = 3355443,
                    Type = AnnotationType.ResourcesRedaction,
                    CreatorName = "Anonym A."
                };
                // Add annotation to list
                annotations.Add(resourceRedactionAnnotationforWords);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Words);
                //ExEnd:AddResourceRedactionAnnotationforWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Removes all annotations in words document
        /// </summary>



        /// <summary>
        /// Add text annotation in cells
        /// </summary>
        /// Update filePath with path to Cells file before using this function
        public static void AddTextAnnotationInCells()
        {
            try
            {
                //ExStart:AddTextAnnotationInCells
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Initialize text annotation.
                AnnotationInfo textAnnotation = new AnnotationInfo
                {
                    PageNumber = 1,
                    AnnotationPosition = new Point(3, 3),
                    FieldText = "Hello!"
                };

                // Add annotation to list
                annotations.Add(textAnnotation);

                // Export annotation and save output file
                CommonUtilities.SaveOutputDocument(inputFile, annotations, DocumentType.Cells);
                //ExEnd:AddTextAnnotationInCells
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        /// <summary>
        /// Import and Export Annotations from Words document.
        /// </summary>
        /// Update filePath with path to word document files before using this function
        public static void ImportAndExportAnnotationsFromWords()
        {
            try
            {
                //ExStart:ImportAndExportAnnotationsFromWords
                // Create instance of annotator. 
                AnnotationConfig cfg = CommonUtilities.GetConfiguration();

                AnnotationImageHandler annotator = new AnnotationImageHandler(cfg);

                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(filePath), FileMode.Open, FileAccess.ReadWrite);

                //importing annotations from Words document
                AnnotationInfo[] annotations = annotator.ImportAnnotations(inputFile, DocumentType.Words);

                //export imported annotation to another document (just for check)
                Stream clearDocument = new FileStream(CommonUtilities.MapDestinationFilePath("Clear.docx"), FileMode.Open, FileAccess.ReadWrite);
                Stream output = annotator.ExportAnnotationsToDocument(clearDocument, annotations.ToList(), DocumentType.Words);


                // Export annotation and save output file
                //save results after export
                using (FileStream fileStream = new FileStream(CommonUtilities.MapDestinationFilePath("AnnotationImportAndExportAnnotated.docx"), FileMode.Create))
                {
                    byte[] buffer = new byte[output.Length];
                    output.Seek(0L, SeekOrigin.Begin);
                    output.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Close();
                }
                //ExEnd:ImportAndExportAnnotationsFromWords
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }

}
