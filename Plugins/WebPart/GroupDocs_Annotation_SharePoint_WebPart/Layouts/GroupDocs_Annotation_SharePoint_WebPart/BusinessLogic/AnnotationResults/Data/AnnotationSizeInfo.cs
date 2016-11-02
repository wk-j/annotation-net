using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GroupDocs_Annotation_SharePoint_WebPart.AnnotationResults.Data
{
    [DataContract(Name = "annotationSizeInfo")]
    public class AnnotationSizeInfo
    {
        [XmlElement("width")]
        [DataMember(Name = "width")]
        public double Width { get; set; }

        [XmlElement("height")]
        [DataMember(Name = "height")]
        public double Height { get; set; }
    }
}
