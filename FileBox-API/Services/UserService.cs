using FileBox_API.Interfaces;
using FileBox_API.Requests;

namespace FileBox_API.Services
{
    
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> RegisterAsyncService(Register_Request registerRequest)
        {
             var result = await _userRepository.RegisterAsyncRepo(registerRequest);
            if(result != -1)
            {

                string path = "C:\\Users\\Ionut\\Desktop\\Licenta Cristi\\Archive\\Files";
                string fullpath= Path.Combine(path, registerRequest.Email);
                if (!Directory.Exists(fullpath))
                    Directory.CreateDirectory(fullpath);
                return result;
            }
            else
            {
                return -1;
            }
        }

    }
}
