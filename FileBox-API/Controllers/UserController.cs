using Microsoft.AspNetCore.Mvc;

namespace FileBox_API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("api/user")]
        public IActionResult Get()
        {
            return Ok("Hello from UserController");
        }
    }
}
