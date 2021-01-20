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

        [HttpGet]
        public IActionResult ImageForTinyMce()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImageForTinyMce(IFormFile uploadFile)
        {
            var newFileName = await _fileService.SaveImageAsync(uploadFile);

            var imageUrl = Url.Action("Image", "File", new { fileName = newFileName });

            return PartialView("ImageHtml", imageUrl);
        }
    }
}
