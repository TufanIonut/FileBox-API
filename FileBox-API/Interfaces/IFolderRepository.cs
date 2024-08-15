using FileBox_API.Requests;
using FileBox_API.Responses;

namespace FileBox_API.Interfaces
{
    public interface IFolderRepository
    {
        Task<int> AddFolderAsyncRepo(AddFolder_Request addFolderRequest);
        Task<IEnumerable<GetFolders_Response>> GetFoldersAsyncRepo(int idUser);
        Task<int> DeleteFolderAsyncRepo(int idFolder);
        Task<int> RenameFolderAsyncRepo(RenameFolder_Request renameFolderRequest);
        Task<int> AddFileInFolderAsyncRepo(AddFileInFolder_Request addFileInFolderRequest);
        Task<GetFiles_Response> GetFilesAsyncInFolderAsyncRepo(int idFolder);
    }
}