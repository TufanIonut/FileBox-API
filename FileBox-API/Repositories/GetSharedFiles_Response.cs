using System.Runtime.CompilerServices;

namespace FileBox_API.Repositories
{
    public class GetSharedFiles_Response
    {
        public int IdSharedFile { get; set; }
        public int IdFile { get; set; }
        public string FileName { get; set; }
        public string FileTypeName { get; set; }
        public string FileLink { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSafe { get; set; }
        public DateTime UploadDate { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverUsername { get; set; }
        public string ReceiverEmail { get; set; }
        public int SenderId { get; set; }
        public string SenderUsername { get; set; }
        public string SenderEmail { get; set; }

    }
}
