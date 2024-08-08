namespace FileBox_API.Requests
{
    public class RenameFile_Request
    {
        public int IdUser { get; set; }
        public string Path { get; set; }
        public string NewFileName { get; set; }

    }
}
