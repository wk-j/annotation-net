using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using GroupDocs_Annotation_SharePoint_WebPart.AnnotationResults.Data;

namespace GroupDocs_Annotation_SharePoint_WebPart.AnnotationResults
{
    [DataContract]
    public class ListAnnotationsResult : Result
    {
        [XmlElement("documentGuid")]
        [DataMember(Name = "documentGuid")]
        public string DocumentGuid { get; set; }

        [XmlElement("annotations")]
        [DataMember(Name = "annotations")]
        public AnnotationInfo[] Annotations { get; set; }

        public DateTime ServerTime { get; set; }
    }
}