using FileBox_API.Requests;

namespace FileBox_API.Interfaces
{
    public interface IUserRepository
    {
        Task<int> LoginAsyncRepo(Login_Request loginRequest);
        Task<int> RegisterAsyncRepo(Register_Request registerRequest);
    }
}