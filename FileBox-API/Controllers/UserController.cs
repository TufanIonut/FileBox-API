using FileBox_API.Interfaces;
using FileBox_API.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FileBox_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        public UserController(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(Login_Register_Request loginRequest)
        {
            var IdUser = await _userRepository.LoginAsyncRepo(loginRequest);
            switch (IdUser)
            {
                case 0:
                    return Ok(IdUser);
                case -1:
                    return BadRequest("Login failed");
                default:
                    string path = "C:\\Users\\Ionut\\Desktop\\Licenta Cristi\\Archive\\Files";
                    string fullpath = Path.Combine(path, loginRequest.Email);
                    if (!Directory.Exists(fullpath))
                        Directory.CreateDirectory(fullpath);
                    return Ok(IdUser);
            }
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync(Login_Register_Request registerRequest)
        {
            var IdUser = await _userService.RegisterAsyncService(registerRequest);
            if (IdUser != -1)
            {
                return Ok(IdUser);
            }
            else
            {
                return BadRequest("User exists already");
            }
        }
    }
}
