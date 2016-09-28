using System.Runtime.Serialization;

namespace GroupDocs.Demo.Annotation.Webforms.AnnotationResults
{
    public interface IResult
    {
    }

    [DataContract()]
    public class Result : IResult
    {
    }
}