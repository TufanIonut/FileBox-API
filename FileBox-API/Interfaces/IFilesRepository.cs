using FileBox_API.Requests;

namespace FileBox_API.Interfaces
{
    public interface IFilesRepository
    {
        Task<int> AddFileAsyncRepo(AddFile_Request addFileRequest);
    }
}