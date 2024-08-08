using FileBox_API.Requests;

namespace FileBox_API.Interfaces
{
    public interface IFilesService
    {
        Task<int> AddFileAsyncService(AddFile_Request addFileRequest);
        Task<int> RenameFileAsyncService(RenameFile_Request renameFileRequest);
    }
}