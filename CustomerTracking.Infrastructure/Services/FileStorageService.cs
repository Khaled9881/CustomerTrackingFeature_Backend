using CustomerTracking.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Infrastructure.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _environment;

        public FileStorageService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveImageAsync(IFormFile file, string subFolder, CancellationToken cancellationToken)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var relativePath = Path.Combine("images", subFolder, fileName).Replace("\\", "/");
            var absolutePath = Path.Combine(_environment.WebRootPath, "images", subFolder, fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(absolutePath)!);

            using var stream = new FileStream(absolutePath, FileMode.Create);
            await file.CopyToAsync(stream, cancellationToken);

            return relativePath;
        }

        public void DeleteImage(string relativePath)
        {
            var absolutePath = Path.Combine(_environment.WebRootPath, relativePath.Replace("/", Path.DirectorySeparatorChar.ToString()));
            if (File.Exists(absolutePath))
            {
                File.Delete(absolutePath);
            }
        }
    }
}
