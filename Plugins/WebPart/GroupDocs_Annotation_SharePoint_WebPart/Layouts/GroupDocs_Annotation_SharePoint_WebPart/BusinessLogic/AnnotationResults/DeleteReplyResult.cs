using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using GroupDocs_Annotation_SharePoint_WebPart.AnnotationResults.Data;

namespace GroupDocs_Annotation_SharePoint_WebPart.AnnotationResults
{
    [DataContract]
    public class DeleteReplyResult : Result
    {
        [XmlElement("replyGuid")]
        [DataMember(Name = "replyGuid")]
        public string ReplyGuid { get; set; }

        [XmlElement("annotationGuid")]
        [DataMember(Name = "annotationGuid")]
        public string Guid { get; set; }

        [XmlElement("replies")]
        [DataMember(Name = "replies")]
        public AnnotationReplyInfo[] Replies { get; set; }

        public DateTime ServerTime { get; set; }
    }
}
