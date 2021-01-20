using System.IO;
using Microsoft.AspNetCore.Mvc;
using SummernoteTest.Services;

namespace SummernoteTest.Controllers
{
    public class FileController : Controller
    {
        private readonly FileService _fileService;

        public FileController(FileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Image(string fileName)
        {
            var dto = _fileService.GetImage(fileName);

            var fileInfo = new FileInfo(dto.FilePath);

            return File(fileInfo.OpenRead(), dto.ContentType, dto.FileName);
        }
    }
}
