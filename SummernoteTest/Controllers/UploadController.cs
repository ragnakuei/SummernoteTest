using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SummernoteTest.Services;

namespace SummernoteTest.Controllers
{
    public class UploadController : Controller
    {
        private readonly FileService _fileService;

        public UploadController(FileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> Image(IFormFile uploadFile)
        {
            var newFileName = await _fileService.SaveImageAsync(uploadFile);

            var imageUrl = Url.Action("Image", "File", new { fileName = newFileName });

            return Ok(imageUrl);
        }
    }
}
