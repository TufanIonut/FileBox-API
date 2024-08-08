using FileBox_API.Requests;

namespace FileBox_API.Interfaces
{
    public interface IUserService
    {
        Task<int> RegisterAsyncService(Register_Request registerRequest);
    }
}