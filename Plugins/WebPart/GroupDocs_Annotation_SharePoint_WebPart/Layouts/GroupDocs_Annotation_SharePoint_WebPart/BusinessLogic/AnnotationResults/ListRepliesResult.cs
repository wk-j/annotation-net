using System.Runtime.Serialization;
using System.Xml.Serialization;
using GroupDocs_Annotation_SharePoint_WebPart.AnnotationResults.Data;

namespace GroupDocs_Annotation_SharePoint_WebPart.AnnotationResults
{
    [DataContract]
    public class ListRepliesResult : Result
    {
        [XmlElement("annotationGuid")]
        [DataMember(Name = "annotationGuid")]
        public string AnnotationGuid { get; set; }

        [XmlElement("replies")]
        [DataMember(Name = "replies")]
        public AnnotationReplyInfo[] Replies { get; set; }
    }
}
