namespace FileBox_API.Requests
{
    public class AddFile_Request
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileLink { get; set; }
    }
}