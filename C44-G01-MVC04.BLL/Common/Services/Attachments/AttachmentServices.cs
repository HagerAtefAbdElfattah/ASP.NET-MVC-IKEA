using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.BLL.Common.Services.Attachments
{
    public class AttachmentServices : IAttachmentServices
    {
        private readonly List<string> AllowedExtension = new List<string>()
        {
            ".jpg",
            ".jpeg",
            ".png",
            ".gif"
        };

        private const int MaxFileSize = 2 * 1024 * 1024; 
        public string UploadImage(IFormFile file, string folderName)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (!AllowedExtension.Contains(fileExtension.ToLower()))
            {
                throw new Exception("Invalid file type. Only image files are allowed.");
            }
            if(file.Length > MaxFileSize)
            {
                throw new Exception("File size exceeds the maximum limit of 2 MB.");
            }

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";

            var filePath = Path.Combine(folderPath, uniqueFileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            {
                file.CopyTo(stream);
            }

            return uniqueFileName;
        }
        public bool DeleteImage(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }
    }
}
