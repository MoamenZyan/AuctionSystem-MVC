using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Infrastructure.Interfaces
{
    public interface IFileSystem
    {
        Task<string?> AddPhoto(Guid photoId, string entityType, IFormFile photo);
        void DeletePhoto(string photoPath); 
    }
}
