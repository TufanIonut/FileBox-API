namespace FileBox_API.Responses
{
    public class GetFiles_Response
    {
        public int IdFile { get; set; }
        public string FileName { get; set; }
        public int IdUser { get; set; }
        public string FileTypeName { get; set; }
        public string FileLink { get; set; }
        public int IsDeleted { get; set; }
        public int IsSafe { get; set; }
        public DateTime UploadDate { get; set; }

    }
}