using FileBox_API.Repositories;
using FileBox_API.Requests;
using FileBox_API.Responses;

namespace FileBox_API.Interfaces
{
    public interface IShareRepository
    {
        Task<IEnumerable<Users_Response>> GetUsersAasyncRepo(int idUser);
        Task<int> InsertSharedFileAsyncRepo(Share_Request shareRequest);
        Task<IEnumerable<Statistics_Response>> GetStatisticsForApplicationAsyncRepo();
        Task<IEnumerable<GetSharedFiles_Response>> GetSharedFilesAsyncRepo(int IdUser);
        Task<int> DeleteSharedFile(int IdSharedFile);
    }
}