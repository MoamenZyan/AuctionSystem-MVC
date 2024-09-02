using AuctionSystemApp.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Infrastructure.Services
{
    public class PhotoService : IFileSystem
    {
        public async Task<string?> AddPhoto(Guid photoId, string entityType, IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
                return null;

            Directory.CreateDirectory(Path.Combine("wwwroot", "AuctionsPhotos"));
            Directory.CreateDirectory(Path.Combine("wwwroot", "UsersPhotos"));

            var filePath = string.Empty;

            if (entityType == "auction")
                filePath = Path.Combine("wwwroot", "AuctionsPhotos", photoId.ToString() + Path.GetExtension(photo.FileName));
            
            else
                filePath = Path.Combine("wwwroot", "UsersPhotos", photoId.ToString() + Path.GetExtension(photo.FileName));
            
            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }
                var relativePath = filePath.Replace("wwwroot", "").Replace("\\", "/");
                return relativePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public void DeletePhoto(string photoPath)
        {
            if (File.Exists(photoPath))
            {
                File.Delete(photoPath);
            }
        }
    }
}
