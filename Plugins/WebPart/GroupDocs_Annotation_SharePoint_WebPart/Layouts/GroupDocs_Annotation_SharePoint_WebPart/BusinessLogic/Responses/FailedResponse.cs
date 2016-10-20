using System;

namespace GroupDocs_Annotation_SharePoint_WebPart.BusinessLogic.Responses
{
    public class FailedResponse
    {
        //[DataMember(Name = "success")]
        public bool success { get; set; }

        //[DataMember(Name = "Reason")]
        public String Reason { get; set; }

        public FailedResponse()
        {
            success = false;
        }
    }

}
