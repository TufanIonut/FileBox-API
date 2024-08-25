namespace FileBox_API.Interfaces
{
    public interface IShareService
    {
        Task<Dictionary<string, long>> CalculateSpaceForFilesAsyncService(string folderPath);
        string FormatSize(long sizeBytes);
    }
}