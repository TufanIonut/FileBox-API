using FileBox_API.Interfaces;
using FileBox_API.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FileBox_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SharesController : ControllerBase
    {
        private readonly IShareRepository _shareRepository;
        
        public SharesController(IShareRepository shareRepository)
        {
            _shareRepository = shareRepository;
        }
        [HttpGet("GetAllUsersExeptMe")]
        public async Task<IActionResult> GetAllUsersAsync(int idUser)
        {
            var result = await _shareRepository.GetUsersAasyncRepo(idUser);
            return Ok(result);
        }
        [HttpPost("InsertSharedFile")]
        public async Task<IActionResult> InsertSharedFileAsync(Share_Request shareRequest)
        {
            var result = await _shareRepository.InsertSharedFileAsyncRepo(shareRequest);
            if(result == 0)
            {
                return BadRequest("File already shared");
            }
            return Ok(result);
        }
        [HttpGet("GetStatisticsForApplication")]
        public async Task<IActionResult> GetStatisticsForApplicationAsync()
        {
            var result = await _shareRepository.GetStatisticsForApplicationAsyncRepo();
            return Ok(result);
        }
        
    }
}
