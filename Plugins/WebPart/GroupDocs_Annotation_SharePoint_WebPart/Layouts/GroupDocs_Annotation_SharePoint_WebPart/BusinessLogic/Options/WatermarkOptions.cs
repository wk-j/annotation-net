using System.Drawing;
using GroupDocs_Annotation_SharePoint_WebPart.AnnotationResults.Data;

namespace GroupDocs_Annotation_SharePoint_WebPart.BusinessLogic.Options
{
    public class WatermarkOptions
    {
        public string Text { get; set; }
        public Color? Color { get; set; }
        public WatermarkPosition Position { get; set; }
        public float FontSize { get; set; }
    }
}
