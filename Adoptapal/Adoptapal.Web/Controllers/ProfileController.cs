using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;
using Adoptapal.Web.FileUploadService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Adoptapal.Web.Controllers
{ 
    public class ProfileController : Controller
    {
        private readonly UserManager _manager;
        private readonly IFileUploadService _uploadService;

        public static string? UserId;
        public static string? FilePath;
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
            UserId = HttpContext.Session.GetString("UserId");

            if (UserId != null)
            {
                User model = _manager.GetUser(UserId);
                return View(model);
            }
            return RedirectToAction("Login", "AccountController");
        }

        [HttpPost]
        public IActionResult UserProfile(IFormFile file)
        {
            OnPost(file);
            if(UserId != null)
            {
                User user = _manager.GetUser(UserId);
                if (user != null)
                {
                    user.PhotoPath = file.FileName;
                    _manager.Update(user);
                }

            }

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
