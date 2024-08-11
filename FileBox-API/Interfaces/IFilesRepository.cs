using FileBox_API.Requests;
using FileBox_API.Responses;

namespace FileBox_API.Interfaces
{
    public interface IFilesRepository
    {
        Task<int> AddFileAsyncRepo(AddFile_Request addFileRequest);
        Task<IEnumerable<GetFiles_Response>> GetFilesAsyncRepo(int idUser);
        Task<IEnumerable<GetFiles_Response>> GetDeletedFilesAsyncRepo(int idUser);
        Task<IEnumerable<GetFiles_Response>> GetSafeFilesAsyncRepo(int idUser);
        Task<int> RenameFileAsyncRepo(RenameFile_Request renameFileRequest, string currentFileName);
        Task<int> SoftDeleteFileAsyncRepo(int idFile);
        Task<int> AddFileToSafeAsyncRepo(int idFile);
        Task<int> RemoveFileFromSafeAsyncRepo(int idFile);
        Task<int> RemoveFileFromBinAsyncRepo(int idFile);
        Task<int> DeleteFileAsyncRepo(string path);
    }
}