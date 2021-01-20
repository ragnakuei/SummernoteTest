using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using SummernoteTest.Models;

namespace SummernoteTest.Services
{
    public class FileService
    {
        static FileService()
        {
            TryCreateFolder(_imageFolder);
        }

        private static readonly string _imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload", "Images");

        private static void TryCreateFolder(string newFileFolder)
        {
            if (Directory.Exists(newFileFolder))
            {
                return;
            }

            Directory.CreateDirectory(newFileFolder);
        }

        public async Task<string> SaveImageAsync(IFormFile fileDto)
        {
            var newFileName = Guid.NewGuid().ToString() + new FileInfo(fileDto.FileName).Extension;

            var filePath = Path.Combine(_imageFolder, newFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await fileDto.CopyToAsync(fileStream);
            }

            return newFileName;
        }

        public FormFileDto GetImage(string fileName)
        {
            return new FormFileDto
                   {
                       FileName    = fileName,
                       FilePath    = Path.Combine(_imageFolder, fileName),
                       ContentType = GetContentType(fileName)
                   };
        }

        private static string GetContentType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            provider.TryGetContentType(fileName, out var contentType);
            return contentType;
        }
    }
}
