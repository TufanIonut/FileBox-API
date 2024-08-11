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
        public async Task<IActionResult> LoginAsync(Login_Request loginRequest)
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
        public async Task<IActionResult> RegisterAsync(Register_Request registerRequest)
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
        [HttpPost]
        [Route("AddProfilePicture")]
        public async Task<IActionResult> AddProfilePictureAsync(Add_UpdatePP_Request addProfilePictureRequest)
        {
            var result = await _userRepository.AddProfilePictureAsyncRepo(addProfilePictureRequest);
            if (result == 1)
            {
                return Ok("Profile picture added");
            }
            else
            {
                return BadRequest("Profile picture not added");
            }
        }
        [HttpPost]
        [Route("AddSafePassword")]
        public async Task<IActionResult> AddSafePasswordAsync(Add_UpdateSafePass_Request addSafePasswordRequest)
        {
            var result = await _userRepository.AddSafePasswordAsyncRepo(addSafePasswordRequest);
            if (result == 1)
            {
                return Ok("Safe password added");
            }
            else
            {
                return BadRequest("Safe password not added");
            }
        }
        [HttpPatch("LoginSafePassword")]
        
        public async Task<IActionResult> LoginSafePasswordAsync(LoginSafePass_Request loginSafePassRequest)
        {
            var result = await _userRepository.LoginSafePasswordAsyncRepo(loginSafePassRequest);
            if (result == 1)
            {
                return Ok("Safe password correct");
            }
            else
            {
                return BadRequest("Safe password incorrect");
            }
        }
    }
}
