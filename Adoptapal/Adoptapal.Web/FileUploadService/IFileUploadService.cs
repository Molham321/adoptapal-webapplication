/*
 * File: IFileUploadService.cs
 * Namespace: Adoptapal.Web.FileUploadService
 * 
 * Description:
 * This file contains the definition of the IFileUploadService interface, which
 * outlines the contract for uploading files asynchronously.
 * 
 */

namespace Adoptapal.Web.FileUploadService
{
    public interface IFileUploadService
    {
        public Task<string> UploadFileAsync(IFormFile fileName);
    }
}
