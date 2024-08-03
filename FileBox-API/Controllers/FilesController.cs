using FileBox_API.Interfaces;
using FileBox_API.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FileBox_API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IFilesService _filesService;
        public FilesController(IFilesService filesService)
        {
            _filesService = filesService;
        }
        [HttpPost("addfile")]
        public async Task<IActionResult> AddFileAsyncController(AddFile_Request addFileRequest)
        {
            try
            {
                var result = await _filesService.AddFileAsyncService(addFileRequest);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
