namespace Adoptapal.Web.FileUploadService
{
    public interface IFileUploadService
    {
        public Task<string> UploadFileAsync(IFormFile fileName);
    }
}
