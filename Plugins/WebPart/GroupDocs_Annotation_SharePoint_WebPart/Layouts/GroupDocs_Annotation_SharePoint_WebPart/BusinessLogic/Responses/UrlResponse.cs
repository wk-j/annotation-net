namespace GroupDocs_Annotation_SharePoint_WebPart.BusinessLogic.Responses
{
    public class UrlResponse : FailedResponse
    {
        public UrlResponse()
        {
        }

        public UrlResponse(string url)
        {
            success = true;
            this.url = url;
        }

        public string url { get; set; }
    }
}
