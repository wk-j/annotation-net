using System.Drawing;
using GroupDocs.Demo.Annotation.Webforms.AnnotationResults.Data;

namespace GroupDocs.Demo.Annotation.Webforms.BusinessLogic.Options
{
    public class WatermarkOptions
    {
        public string Text { get; set; }
        public Color? Color { get; set; }
        public WatermarkPosition Position { get; set; }
        public float FontSize { get; set; }
    }
}
