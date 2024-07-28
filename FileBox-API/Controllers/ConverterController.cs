using FileBox_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FileBox_API.Controllers
{
    [ApiController]
    [Route("api/converter")]


    public class ConverterController : ControllerBase
    {
        private readonly IWordToPdfService _wordToPdfService;
        public ConverterController(IWordToPdfService wordToPdfService)
        {
            _wordToPdfService = wordToPdfService;
        }

        [HttpPost]
        [Route("wordtopdf")]
        public IActionResult WordToPdf(string path)
        {

            try
            {
                string pdfPath = _wordToPdfService.ConvertWordToPdf(path);

                var pdfFileStream = new FileStream(pdfPath, FileMode.Open, FileAccess.Read);
                return File(pdfFileStream, "application/pdf", Path.GetFileName(pdfPath));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
