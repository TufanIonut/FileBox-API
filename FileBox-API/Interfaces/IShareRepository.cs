using FileBox_API.Repositories;

namespace FileBox_API.Interfaces
{
    public interface IShareRepository
    {
        Task<IEnumerable<Users_Response>> GetUsersAasyncRepo(int idUser);
    }
}