using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.FileUpload
{
    public static class FlagImage
    {
        private static string path = Path.Combine("wwwroot", "images");
        public static string UploadFlagImage(IFormFile image)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(image.FileName);

            var newFileName = guid + extension;

            var uploadPath = Path.Combine(path, newFileName);

            using(var filestream = new FileStream(uploadPath, FileMode.Create))
            {
                image.CopyTo(filestream);
            }

            return newFileName;       
        }

        public static string UpdateFlagImage(IFormFile image, string fileName)
        {
            var deletePath = Path.Combine(path, fileName);
            if (File.Exists(deletePath))
            {
                File.Delete(deletePath);
            }

            return UploadFlagImage(image);
        }

        public static void RemoveFile(string fileName)
        {
            var deletePath = Path.Combine(path, fileName);
            if (File.Exists(deletePath))
            {
                File.Delete(deletePath);
            }
        }
    }
}
