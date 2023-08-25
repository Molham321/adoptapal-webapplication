
/*
 * File: LocalFileUploadService.cs
 * Namespace: Adoptapal.Web.FileUploadService
 * 
 * Description:
 * This file contains the implementation of the LocalFileUploadService class,
 * which provides functionality to upload files to the local file system.
 * 
 */

using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Adoptapal.Web.FileUploadService
{
    public class LocalFileUploadService : IFileUploadService
    {
        private readonly IHostingEnvironment environment;

        public LocalFileUploadService(IHostingEnvironment environment)
        {
            this.environment = environment;
        }
        public async Task<string> UploadFileAsync(IFormFile fileName)
        {
            var filePath = Path.Combine(environment.ContentRootPath, @"wwwroot\images", fileName.FileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await fileName.CopyToAsync(fileStream);
            return filePath;
        }
    }
}
