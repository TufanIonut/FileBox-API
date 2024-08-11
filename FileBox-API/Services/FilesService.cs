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
                finalPath.Replace(@"\", @"\\");
                addFileRequest.FileLink = finalPath;

                addFileRequest.FileType = extension;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            var resultRepo = await _filesRepository.AddFileAsyncRepo(addFileRequest);
            return resultRepo;
        }
        public async Task<int> RenameFileAsyncService(RenameFile_Request renameFileRequest)
        {
            if (string.IsNullOrEmpty(renameFileRequest.Path) || !System.IO.File.Exists(renameFileRequest.Path))
            {
                throw new Exception("File not found");
            }

            try
            {
                string curentFileName = Path.GetFileName(renameFileRequest.Path);
                string directory = Path.GetDirectoryName(renameFileRequest.Path);


                string extension = Path.GetExtension(renameFileRequest.Path); 
                string newFilePath = Path.Combine(directory, renameFileRequest.NewFileName + extension);
                
                System.IO.File.Move(renameFileRequest.Path, newFilePath);
                var curentFileNameWithoutExtension = Path.GetFileNameWithoutExtension(renameFileRequest.Path);
                renameFileRequest.Path = newFilePath;
                
                int resultRepo = await _filesRepository.RenameFileAsyncRepo(renameFileRequest, curentFileNameWithoutExtension);

                return resultRepo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteFileAsyncService(string path)
        {
            if (string.IsNullOrEmpty(path) || !System.IO.File.Exists(path))
            {
                throw new Exception("File not found");
            }

            try
            {
                System.IO.File.Delete(path);
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            var resultRepo = await _filesRepository.DeleteFileAsyncRepo(path);
            return resultRepo;
        }
    }
}
