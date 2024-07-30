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
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
                    return Ok(IdUser);
            }
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync(Login_Register_Request registerRequest)
        {
            var IdUser = await _userRepository.RegisterAsyncRepo(registerRequest);
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
