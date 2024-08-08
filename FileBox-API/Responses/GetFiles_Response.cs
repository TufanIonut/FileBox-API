namespace FileBox_API.Responses
{
    public class GetFiles_Response
    {
        public int IdFile { get; set; }
        public string FileName { get; set; }
        public int IdUser { get; set; }
        public string FileTypeName { get; set; }
        public string FileLink { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSafe { get; set; }
        public DateTime UploadDate { get; set; }

    }
}