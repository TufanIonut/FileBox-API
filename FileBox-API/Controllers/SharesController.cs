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
        private readonly IShareService _shareService;
        public SharesController(IShareRepository shareRepository, IShareService shareService)
        {
            _shareRepository = shareRepository;
            _shareService = shareService;
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

        [HttpGet("GetSharedFiles")]
        public async Task<IActionResult> GetSharedFilesAsync(int IdUser)
        {
            var result = await _shareRepository.GetSharedFilesAsyncRepo(IdUser);
            return Ok(result);
        }
        [HttpPost("GetSpaceForFiles")]
        public async Task<Dictionary<string,string>> GetSpaceFiles(string folderPath)
        {
            var result = await _shareService.CalculateSpaceForFilesAsyncService(folderPath);
            var formattedResult = result.ToDictionary(
            item => item.Key,
            item => _shareService.FormatSize(item.Value));

            return formattedResult;
        }
        [HttpDelete("DeleteSharedFile")]
        public async Task<IActionResult> DeleteSharedFile(int IdSharedFile)
        {
            var result = await _shareRepository.DeleteSharedFile(IdSharedFile);
            if(result == 0)
            {
                return BadRequest("file does not exist");
            }
            return Ok("Delete successful");
        }
    }
}
