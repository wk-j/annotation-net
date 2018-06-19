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
    class DiagramsAnnotation
    {


        /// <summary>
        /// Adds Area annotation in Diagrams
        /// </summary>
        public static void AddAreaAnnotationInDiagrams()
        {
            try
            {
                //ExStart:AddAreaAnnotationInDiagrams
                // Create instance of annotator. 
                AnnotationConfig cfg = CommonUtilities.GetConfiguration();
                AnnotationImageHandler annotator = new AnnotationImageHandler(cfg);
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Initialize area annotation
                AnnotationInfo areaAnnnotation = new AnnotationInfo()
                {
                    CreatedOn = DateTime.Now,
                    Type = AnnotationType.Area,
                    Box = new Rectangle(200, 114.5f, 282.3f, 103.7f),
                };
                // Add annotation to list
                annotations.Add(areaAnnnotation);

                // Get output file stream
                Stream result = annotator.ExportAnnotationsToDocument(inputFile, annotations);

                // Save result stream to file.
                using (FileStream fileStream = new FileStream(CommonUtilities.MapDestinationFilePath("Annotated.vsdx"), FileMode.Create))
                {
                    byte[] buffer = new byte[result.Length];
                    result.Seek(0, SeekOrigin.Begin);
                    result.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Close();
                }
                //ExEnd:AddAreaAnnotationInDiagrams
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds Polyline annotation in Diagrams
        /// </summary>
        public static void AddPolylineAnnotationInDiagrams()
        {
            try
            {
                //ExStart:AddPolylineAnnotationInDiagrams
                // Create instance of annotator. 
                AnnotationConfig cfg = CommonUtilities.GetConfiguration();
                AnnotationImageHandler annotator = new AnnotationImageHandler(cfg);
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Initialize polyline annotation
                AnnotationInfo polylineAnnotation = new AnnotationInfo
                {
                    CreatedOn = DateTime.Now,
                    Type = AnnotationType.Polyline,
                    Box = new Rectangle(206.3f, 106.61f, 456.04f, 307.97f),
                    SvgPath = "M436.293427230047,148.06338028169014l0,-0.9870892018779343l-0.9870892018779343,-0.9870892018779343l-1.9741784037558685,-0.9870892018779343l-0.9870892018779343,0l-0.9870892018779343,-0.9870892018779343l-1.9741784037558685,-0.9870892018779343l-0.9870892018779343,0l-1.9741784037558685,-0.9870892018779343l-1.9741784037558685,0l-4.935446009389671,-1.9741784037558685l-1.9741784037558685,0l-1.9741784037558685,-0.9870892018779343l-1.9741784037558685,0l-1.9741784037558685,-0.9870892018779343l-2.961267605633803,0l-2.961267605633803,0l-2.961267605633803,0l-2.961267605633803,0l-2.961267605633803,0l-2.961267605633803,0l-1.9741784037558685,0l-3.948356807511737,0l-2.961267605633803,0l-3.948356807511737,0l-4.935446009389671,0l-3.948356807511737,0.9870892018779343l-4.935446009389671,0.9870892018779343l-6.90962441314554,0l-3.948356807511737,0.9870892018779343l-3.948356807511737,0l-2.961267605633803,1.9741784037558685l-3.948356807511737,0.9870892018779343l-6.90962441314554,1.9741784037558685l-6.90962441314554,0.9870892018779343l-12.832159624413146,2.961267605633803l-6.90962441314554,1.9741784037558685l-5.922535211267606,0.9870892018779343l-5.922535211267606,1.9741784037558685l-5.922535211267606,1.9741784037558685l-5.922535211267606,0.9870892018779343l-4.935446009389671,1.9741784037558685l-5.922535211267606,1.9741784037558685l-5.922535211267606,1.9741784037558685l-4.935446009389671,1.9741784037558685l-5.922535211267606,2.961267605633803l-5.922535211267606,3.948356807511737l-5.922535211267606,3.948356807511737l-4.935446009389671,3.948356807511737l-5.922535211267606,3.948356807511737l-5.922535211267606,3.948356807511737l-3.948356807511737,5.922535211267606l-        3.948356807511737,4.935446009389671l-3.948356807511737,5.922535211267606l-3.948356807511737,6.90962441314554l-3.948356807511737,7.896713615023474l-0.9870892018779343,6.90962441314554l-1.9741784037558685,7.896713615023474l-1.9741784037558685,6.90962441314554l-0.9870892018779343,7.896713615023474l0,12.832159624413146l0,7.896713615023474l0,7.896713615023474l0.9870892018779343,7.896713615023474l1.9741784037558685,5.922535211267606l2.961267605633803,5.922535211267606l0.9870892018779343,5.922535211267606l2.961267605633803,6.90962441314554l3.948356807511737,5.922535211267606l4.935446009389671,4.935446009389671l3.948356807511737,5.922535211267606l3.948356807511737,5.922535211267606l3.948356807511737,5.922535211267606l5.922535211267606,5.922535211267606l5.922535211267606,5.922535211267606l5.922535211267606,5.922535211267606l6.90962441314554,5.922535211267606l7.896713615023474,5.922535211267606l7.896713615023474,5.922535211267606l17.767605633802816,8.883802816901408l11.845070422535212,3.948356807511737l11.845070422535212,4.935446009389671l23.690140845070424,8.883802816901408l41.45774647887324,6.90962441314554l31.586854460093896,3.948356807511737l16.780516431924884,0l16.780516431924884,1.9741784037558685l16.780516431924884,0l16.780516431924884,0l16.780516431924884,0l16.780516431924884,0l16.780516431924884,-1.9741784037558685l14.806338028169014,-1.9741784037558685l14.806338028169014,-1.9741784037558685l12.832159624413146,-1.9741784037558685l10.857981220657276,-2.961267605633803l10.857981220657276,-2.961267605633803l8.883802816901408,-4.935446009389671l8.883802816901408,-4.935446009389671l6.90962441314554,-6.90962441314554l6.90962441314554,-6.90962441314554l8.883802816901408,-16.780516431924884l4.935446009389671,-7.896713615023474l3.948356807511737,-8.883802816901408l4.935446009389671,-7.896713615023474l4.935446009389671,-7.896713615023474l3.948356807511737,-13.81924882629108l1.9741784037558685,-18.754694835680752l0,-7.896713615023474l0,-12.832159624413146l-1.9741784037558685,-15.793427230046948l-1.9741784037558685,-15.793427230046948l-4.935446009389671,-15.793427230046948l-8.883802816901408,-15.793427230046948l-12.832159624413146,-23.690140845070424l-10.857981220657276,-10.857981220657276l-5.922535211267606,-3.948356807511737l-12.832159624413146,-8.883802816901408l-9.870892018779342,-8.883802816901408l-5.922535211267606,-3.948356807511737l-12.832159624413146,-5.922535211267606l-15.793427230046948,-8.883802816901408l-13.81924882629108,-4.935446009389671l-11.845070422535212,-2.961267605633803l-11.845070422535212,-3.948356807511737l-11.845070422535212,-3.948356807511737l-5.922535211267606,-1.9741784037558685l-11.845070422535212,-2.961267605633803l-11.845070422535212,-1.9741784037558685l-5.922535211267606,-0.9870892018779343l-10.857981220657276,-1.9741784037558685l-10.857981220657276,-2.961267605633803l-9.870892018779342,0l-0.9870892018779343,0l-0.9870892018779343,0l-0.9870892018779343,0l-0.9870892018779343,0l0,-0.9870892018779343l1.9741784037558685,0",
                };
                // Add annotation to list
                annotations.Add(polylineAnnotation);

                // Get output file stream
                Stream result = annotator.ExportAnnotationsToDocument(inputFile, annotations);

                // Save result stream to file.
                using (FileStream fileStream = new FileStream(CommonUtilities.MapDestinationFilePath("Annotated.vsdx"), FileMode.Create))
                {
                    byte[] buffer = new byte[result.Length];
                    result.Seek(0, SeekOrigin.Begin);
                    result.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Close();
                }
                //ExEnd:AddPolylineAnnotationInDiagrams
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds TextField annotation in Diagrams
        /// </summary>
        public static void AddTextFieldAnnotationInDiagrams()
        {
            try
            {
                //ExStart:AddTextFieldAnnotationInDiagrams
                // Create instance of annotator. 
                AnnotationConfig cfg = CommonUtilities.GetConfiguration();
                AnnotationImageHandler annotator = new AnnotationImageHandler(cfg);
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Initialize textfield annotation
                AnnotationInfo textFieldAnnotation = new AnnotationInfo
                {
                    CreatedOn = DateTime.Now,
                    Type = AnnotationType.TextField,
                    Box = new Rectangle(162.87f, 267.5f, 91.8f, 42.45f),
                    BackgroundColor = -15988609,
                    FieldText = "Annotation Text"
                };
                // Add annotation to list
                annotations.Add(textFieldAnnotation);

                // Get output file stream
                Stream result = annotator.ExportAnnotationsToDocument(inputFile, annotations);

                // Save result stream to file.
                using (FileStream fileStream = new FileStream(CommonUtilities.MapDestinationFilePath("Annotated.vsdx"), FileMode.Create))
                {
                    byte[] buffer = new byte[result.Length];
                    result.Seek(0, SeekOrigin.Begin);
                    result.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Close();
                }
                //ExEnd:AddTextFieldAnnotationInDiagrams
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds Arrow annotation in Diagrams
        /// </summary>
        public static void AddArrowAnnotationInDiagrams()
        {
            try
            {
                //ExStart:AddArrowAnnotationInDiagrams
                // Create instance of annotator. 
                AnnotationConfig cfg = CommonUtilities.GetConfiguration();
                AnnotationImageHandler annotator = new AnnotationImageHandler(cfg);
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Initialize arrow annotation
                AnnotationInfo arrowAnnotation = new AnnotationInfo
                {
                    Type = AnnotationType.Arrow,
                    Box = new Rectangle(435.77464788732397f, 148.05164319248826f, -66.34389671361504f, 53.07511737089203f)
                };
                // Add annotation to list
                annotations.Add(arrowAnnotation);

                // Get output file stream
                Stream result = annotator.ExportAnnotationsToDocument(inputFile, annotations);

                // Save result stream to file.
                using (FileStream fileStream = new FileStream(CommonUtilities.MapDestinationFilePath("Annotated.vsdx"), FileMode.Create))
                {
                    byte[] buffer = new byte[result.Length];
                    result.Seek(0, SeekOrigin.Begin);
                    result.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Close();
                }
                //ExEnd:AddArrowAnnotationInDiagrams
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds Resource Redaction annotation in Diagrams
        /// </summary>
        public static void AddResourceRedactionAnnotationInDiagrams()
        {
            try
            {
                //ExStart:AddResourceRedactionAnnotationInDiagrams
                // Create instance of annotator. 
                AnnotationConfig cfg = CommonUtilities.GetConfiguration();
                AnnotationImageHandler annotator = new AnnotationImageHandler(cfg);
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Initialize resource reduction annotation
                AnnotationInfo resourceRedactionAnnotation = new AnnotationInfo
                {
                    Type = AnnotationType.ResourcesRedaction,
                    Box = new Rectangle(200, 114.5f, 282.3f, 103.7f),
                };

                // Add annotation to list
                annotations.Add(resourceRedactionAnnotation);

                // Get output file stream
                Stream result = annotator.ExportAnnotationsToDocument(inputFile, annotations);

                // Save result stream to file.
                using (FileStream fileStream = new FileStream(CommonUtilities.MapDestinationFilePath("Annotated.vsdx"), FileMode.Create))
                {
                    byte[] buffer = new byte[result.Length];
                    result.Seek(0, SeekOrigin.Begin);
                    result.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Close();
                }
                //ExEnd:AddResourceRedactionAnnotationInDiagrams
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds Distance annotation in Diagrams
        /// </summary>
        public static void AddDistanceAnnotationInDiagrams()
        {
            try
            {
                //ExStart:AddDistanceAnnotationInDiagrams
                // Create instance of annotator. 
                AnnotationConfig cfg = CommonUtilities.GetConfiguration();
                AnnotationImageHandler annotator = new AnnotationImageHandler(cfg);
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Initialize distance annotation
                AnnotationInfo distanceAnnnotation = new AnnotationInfo
                {
                    Box = new Rectangle((float)248.73202514648438, (float)287.85653686523438, (float)115.9178466796875, (float)25.143020629882812),
                    CreatedOn = DateTime.Now,
                    Opacity = 0.3,
                    PageNumber = 0,
                    SvgPath = "M248.73201877934272,295.5439436619718 l115.28309859154929,-4.192112676056338",
                    Type = AnnotationType.Distance,
                };

                // Add annotation to list
                annotations.Add(distanceAnnnotation);

                // Get output file stream
                Stream result = annotator.ExportAnnotationsToDocument(inputFile, annotations);

                // Save result stream to file.
                using (FileStream fileStream = new FileStream(CommonUtilities.MapDestinationFilePath("Annotated.vsdx"), FileMode.Create))
                {
                    byte[] buffer = new byte[result.Length];
                    result.Seek(0, SeekOrigin.Begin);
                    result.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Close();
                }
                //ExEnd:AddDistanceAnnotationInDiagrams
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds Point annotation in Diagrams
        /// </summary>
        public static void AddPointAnnotationInDiagrams()
        {
            try
            {
                //ExStart:AddPointAnnotationInDiagrams
                // Create instance of annotator. 
                AnnotationConfig cfg = CommonUtilities.GetConfiguration();
                AnnotationImageHandler annotator = new AnnotationImageHandler(cfg);
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Initialize point annotation
                AnnotationInfo pointAnnnotation = new AnnotationInfo()
                {
                    Box = new Rectangle(150.32f, 99.22f, 0, 0),
                    CreatedOn = DateTime.Now,
                    PageNumber = 0,
                    Type = AnnotationType.Point,
                };

                // Add annotation to list
                annotations.Add(pointAnnnotation);

                // Get output file stream
                Stream result = annotator.ExportAnnotationsToDocument(inputFile, annotations);

                // Save result stream to file.
                using (FileStream fileStream = new FileStream(CommonUtilities.MapDestinationFilePath("Annotated.vsdx"), FileMode.Create))
                {
                    byte[] buffer = new byte[result.Length];
                    result.Seek(0, SeekOrigin.Begin);
                    result.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Close();
                }
                //ExEnd:AddPointAnnotationInDiagrams
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Adds Watermark annotation in Diagrams
        /// </summary>
        public static void AddWatermarkAnnotationInDiagrams()
        {
            try
            {
                //ExStart:AddWatermarkAnnotationInDiagrams
                // Create instance of annotator. 
                AnnotationConfig cfg = CommonUtilities.GetConfiguration();
                AnnotationImageHandler annotator = new AnnotationImageHandler(cfg);
                // Get input file stream
                Stream inputFile = new FileStream(CommonUtilities.MapSourceFilePath(CommonUtilities.filePath), FileMode.Open, FileAccess.ReadWrite);

                // Initialize list of AnnotationInfo
                List<AnnotationInfo> annotations = new List<AnnotationInfo>();

                // Initialize watermark annotation
                AnnotationInfo watermarkAnnnotation = new AnnotationInfo()
                {
                    Box = new Rectangle(165.41f, 192.24f, 177.8f, 38.29f),
                    CreatedOn = DateTime.Now,
                    FieldText = "Watermark text",
                    FontColor = 16711680,
                    FontFamily = "Microsoft Sans Serif",
                    FontSize = 17,
                    Opacity = 0.3,
                    Type = AnnotationType.Watermark,
                };

                // Add annotation to list
                annotations.Add(watermarkAnnnotation);

                // Get output file stream
                Stream result = annotator.ExportAnnotationsToDocument(inputFile, annotations);

                // Save result stream to file.
                using (FileStream fileStream = new FileStream(CommonUtilities.MapDestinationFilePath("Annotated.vsdx"), FileMode.Create))
                {
                    byte[] buffer = new byte[result.Length];
                    result.Seek(0, SeekOrigin.Begin);
                    result.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Close();
                }
                //ExEnd:AddWatermarkAnnotationInDiagrams
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

    }
}
