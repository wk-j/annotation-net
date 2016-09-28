using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using GroupDocs.Demo.Annotation.Webforms.AnnotationResults.Data;

namespace GroupDocs.Demo.Annotation.Webforms.AnnotationResults
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