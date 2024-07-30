using FileBox_API.Requests;

namespace FileBox_API.Interfaces
{
    public interface IUserRepository
    {
        Task<int> LoginAsyncRepo(Login_Register_Request loginRequest);
        Task<int> RegisterAsyncRepo(Login_Register_Request registerRequest);
    }
}