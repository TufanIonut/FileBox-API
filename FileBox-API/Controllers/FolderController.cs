using FileBox_API.Interfaces;
using FileBox_API.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FileBox_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IFolderRepository _folderRepository;
        public FolderController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }
        [HttpPost]
        [Route("AddFolder")]
        public async Task<IActionResult> AddFolder(AddFolder_Request addFolder_Request)
        {
            var result = await _folderRepository.AddFolderAsyncRepo(addFolder_Request);
            if(result == 1)
            {
                return Ok("Folder added successfully");
            }
            else
            {
                return BadRequest("Folder already exists");
            }
        }
        [HttpGet]
        [Route("GetFolders")]
        public async Task<IActionResult> GetFolders(int idUser)
        {
            var result = await _folderRepository.GetFoldersAsyncRepo(idUser);
            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No folders found");
            }
        }
        [HttpDelete]
        [Route("DeleteFolder")]
        public async Task<IActionResult> DeleteFolder(int idFolder)
        {
            var result = await _folderRepository.DeleteFolderAsyncRepo(idFolder);
            if(result == 1)
            {
                return Ok("Folder deleted successfully");
            }
            else
            {
                return BadRequest("Folder not found");
            }
        }
        [HttpPatch]
        [Route("RenameFolder")]
        public async Task<IActionResult> RenameFolder(RenameFolder_Request renameFolder_Request)
        {
            var result = await _folderRepository.RenameFolderAsyncRepo(renameFolder_Request);
            if(result == 1)
            {
                return Ok("Folder renamed successfully");
            }
            else
            {
                return BadRequest("Folder not found");
            }
        }
        [HttpPost]
        [Route("AddFileInFolder")]
        public async Task<IActionResult> AddFileInFolder(AddFileInFolder_Request addFileInFolder_Request)
        {
            var result = await _folderRepository.AddFileInFolderAsyncRepo(addFileInFolder_Request);
            if(result == 1)
            {
                return Ok("File added successfully");
            }
            else
            {
                return BadRequest("File already exists");
            }
        }
        [HttpGet]
        [Route("GetFilesInFolder")]
        public async Task<IActionResult> GetFilesInFolder(int idFolder)
        {
            var result = await _folderRepository.GetFilesAsyncInFolderAsyncRepo(idFolder);
            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No files found");
            }
        }

    }
}
