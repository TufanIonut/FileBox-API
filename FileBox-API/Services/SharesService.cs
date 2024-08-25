using FileBox_API.Interfaces;

namespace FileBox_API.Services
{
    public class SharesService : IShareService
    {
        public SharesService() { }  
       
        public async Task<Dictionary<string, long>> CalculateSpaceForFilesAsyncService(string folderPath)
        {
            return await Task.Run(() => CalculateSpaceForFiles(folderPath));
        }

        private Dictionary<string, long> CalculateSpaceForFiles(string folderPath)
        {
            var fileTypeSizes = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

            var files = Directory.EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var fileExtension = fileInfo.Extension;

                if (fileTypeSizes.ContainsKey(fileExtension))
                {
                    fileTypeSizes[fileExtension] += fileInfo.Length;
                }
                else
                {
                    fileTypeSizes[fileExtension] = fileInfo.Length;
                }
            }

            return fileTypeSizes;
        }

        public string FormatSize(long sizeBytes)
        {
            if (sizeBytes < 1024)
            {
                return $"{sizeBytes} B";
            }
            else if (sizeBytes < 1024 * 1024)
            {
                return $"{sizeBytes / 1024.0:F2} KB";
            }
            else if (sizeBytes < 1024 * 1024 * 1024)
            {
                return $"{sizeBytes / (1024.0 * 1024.0):F2} MB";
            }
            else
            {
                return $"{sizeBytes / (1024.0 * 1024.0 * 1024.0):F2} GB";
            }
        }
    }
}
