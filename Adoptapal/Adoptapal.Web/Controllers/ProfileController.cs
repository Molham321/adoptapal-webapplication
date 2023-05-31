using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;
using Adoptapal.Web.FileUploadService;
using Microsoft.AspNetCore.Mvc;

namespace Adoptapal.Web.Controllers
{ 
    public class ProfileController : Controller
    {
        private readonly UserManager _manager;
        private readonly IFileUploadService _uploadService;

        public string UserId;
        public string FilePath;
        public ProfileController(UserManager manager, IFileUploadService uploadService) : base()
        {
            _manager = manager;
            _uploadService = uploadService;
        }
        public IActionResult Index()
        {
            return RedirectToAction("UserProfile");
        }

        public IActionResult UserProfile()
        {
            this.UserId= HttpContext.Session.GetString("UserId");
            Guid guidValue;

            bool isValidGuid = Guid.TryParse(this.UserId, out guidValue);

            if (isValidGuid)
            {
                User model = _manager.GetUser(guidValue);
                return View(model);
            }
            return RedirectToAction("Login", "AccountController");
        }

        [HttpPost]
        public IActionResult UserProfile(IFormFile file)
        {
            OnPost(file);
            return RedirectToAction("Index");
        }

        public async void OnPost(IFormFile file)
        {
            if (file != null)
            {
                FilePath = await _uploadService.UploadFileAsync(file);
            }
        }
    }
}
