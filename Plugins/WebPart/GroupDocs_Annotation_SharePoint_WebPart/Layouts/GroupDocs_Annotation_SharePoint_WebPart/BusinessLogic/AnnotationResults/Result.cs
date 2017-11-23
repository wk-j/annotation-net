using System.Runtime.Serialization;

namespace GroupDocs_Annotation_SharePoint_WebPart.AnnotationResults
{
    public interface IResult
    {
    }

    [DataContract()]
    public class Result : IResult
    {
    }
}