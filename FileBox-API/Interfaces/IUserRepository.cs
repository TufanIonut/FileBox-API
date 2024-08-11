using FileBox_API.Requests;

namespace FileBox_API.Interfaces
{
    public interface IUserRepository
    {
        Task<int> LoginAsyncRepo(Login_Request loginRequest);
        Task<int> RegisterAsyncRepo(Register_Request registerRequest);
        Task<int> AddProfilePictureAsyncRepo(Add_UpdatePP_Request addProfilePictureRequest);
        Task<int> AddSafePasswordAsyncRepo(Add_UpdateSafePass_Request addSafePasswordRequest);
        Task<int> LoginSafePasswordAsyncRepo(LoginSafePass_Request loginSafePasswordRequest);
    }
}