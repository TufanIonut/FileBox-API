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
        private readonly IFilesRepository _filesRepository;
        public FilesController(IFilesService filesService, IFilesRepository filesRepository)
        {
            _filesService = filesService;
            _filesRepository = filesRepository;
        }
        [HttpPost("addFile")]
        public async Task<IActionResult> AddFileAsyncController(AddFile_Request addFileRequest)
        {
            try
            {
                var result = await _filesService.AddFileAsyncService(addFileRequest);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("File already existent");
            }
        }
        [HttpGet("getFiles")]
        public async Task<IActionResult> GetFilesAsyncController(int idUser)
        {
            try
            {
                var result = await _filesRepository.GetFilesAsyncRepo(idUser);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("No files found");
            }
        }
        [HttpGet("getSafeFiles")]
        public async Task<IActionResult> GetSafeFilesAsyncController(int idUser)
        {
            try
            {
                var result = await _filesRepository.GetSafeFilesAsyncRepo(idUser);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("No files found");
            }
        }
        [HttpGet("getDeletedFiles")]
        public async Task<IActionResult> GetDeletedFilesAsyncController(int idUser)
        {
            try
            {
                var result = await _filesRepository.GetDeletedFilesAsyncRepo(idUser);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("No files found");
            }
        }
        [HttpPatch("renameFile")]
        public async Task<IActionResult> RenameFileAsyncController(RenameFile_Request renameFileRequest )
        {
            try
            {
                var result = await _filesService.RenameFileAsyncService(renameFileRequest);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("File not found");
            }
        }

    }
}
