using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> SaveImageAsync(IFormFile file, string subFolder, CancellationToken cancellationToken);
        void DeleteImage(string relativePath);
    }
}
