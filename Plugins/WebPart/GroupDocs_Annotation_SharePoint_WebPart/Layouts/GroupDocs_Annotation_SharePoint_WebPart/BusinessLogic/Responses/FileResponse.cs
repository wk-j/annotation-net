namespace GroupDocs_Annotation_SharePoint_WebPart.BusinessLogic.Responses
{
    public class FileResponse : FailedResponse
    {
        public FileResponse()
        {
        }

        public FileResponse(string path)
        {
            success = true;
            this.fileId = path;
        }

        public string fileId { get; set; }
    }
}
