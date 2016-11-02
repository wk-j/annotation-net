using System.Runtime.Serialization;
using System.Xml.Serialization;
using GroupDocs_Annotation_SharePoint_WebPart.AnnotationResults.Data;

namespace GroupDocs_Annotation_SharePoint_WebPart.AnnotationResults
{
    [DataContract]
    public class SetCollaboratorsResult : Result
    {
        [XmlElement("documentGuid")]
        [DataMember(Name = "documentGuid")]
        public string DocumentGuid { get; set; }

        [XmlElement("owner")]
        [DataMember(Name = "owner")]
        public ReviewerInfo Owner { get; set; }

        [XmlElement("collaborators")]
        [DataMember(Name = "collaborators")]
        public ReviewerInfo[] Collaborators { get; set; }
    }
}
