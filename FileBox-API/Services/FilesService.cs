using FileBox_API.Interfaces;
using FileBox_API.Requests;

namespace FileBox_API.Services
{
    public class FilesService : IFilesService
    {
        private readonly IFilesRepository _filesRepository;
        private readonly string _assetsPath = "C:\\Users\\Ionut\\Desktop\\Licenta Cristi\\Archive\\Files";
        public FilesService(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }
        public async Task<int> AddFileAsyncService(AddFile_Request addFileRequest)
        {
            if (string.IsNullOrEmpty(addFileRequest.FileLink) || !System.IO.File.Exists(addFileRequest.FileLink))
            {
                throw new Exception("File not found");
            }

            try
            {
                string extension = Path.GetExtension(addFileRequest.FileLink);
                string targetPath = Path.Combine(_assetsPath, addFileRequest.Email);

                string finalPath = Path.Combine(targetPath, addFileRequest.FileName+extension);
                System.IO.File.Copy(addFileRequest.FileLink, finalPath);

                await Task.CompletedTask;

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            var resultRepo = await _filesRepository.AddFileAsyncRepo(addFileRequest);
            return resultRepo;
        }
    }
}
