namespace FileBox_API.Requests
{
    public class Share_Request
    {
        public int IdFile { get; set; }
        public int IdSender { get; set; }
        public int IdReceiver { get; set; }
    }
}