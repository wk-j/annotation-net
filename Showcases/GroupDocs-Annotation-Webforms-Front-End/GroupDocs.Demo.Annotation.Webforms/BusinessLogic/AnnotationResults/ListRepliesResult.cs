using System.Runtime.Serialization;
using System.Xml.Serialization;
using GroupDocs.Demo.Annotation.Webforms.AnnotationResults.Data;

namespace GroupDocs.Demo.Annotation.Webforms.AnnotationResults
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
