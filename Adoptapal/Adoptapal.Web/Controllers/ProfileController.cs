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
        private readonly AnimalManager _animalManager;
        private readonly IFileUploadService _uploadService;

        public static string? UserId;
        public static string? FilePath;
        public ProfileController(UserManager manager, AnimalManager animalManager, IFileUploadService uploadService) : base()
        {
            _manager = manager;
            _animalManager = animalManager;
            _uploadService = uploadService;
        }
        public IActionResult Index()
        {
            return RedirectToAction("UserProfile");
        }

        //public async Task<IActionResult> UserProfile()
        //{
        //    UserId = HttpContext.Session.GetString("UserId");

        //    if (UserId != null)
        //    {
        //        User model = await _manager.GetUserByIdAsync(UserId);
        //        return View(model);
        //    }
        //    return RedirectToAction("Login", "AccountController");
        //}

        public async Task<IActionResult> UserProfile(Guid? id)
        {
            if (id == null)
            {
                UserId = HttpContext.Session.GetString("UserId");
                if(UserId != null)
                {
                    User model = await _manager.GetUserByIdAsync(UserId);
                    return View(model);
                } else
                {
                    return RedirectToAction("Login", "AccountController");
                }
            } else
            {
                var animal = await _animalManager.GetAnimalByIdAsync(id.Value);
                if (animal == null)
                {
                    return NotFound();
                }

                return View(animal.User);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserProfile(IFormFile file)
        {
            OnPost(file);
            if(UserId != null)
            {
                User user = await _manager.GetUserByIdAsync(UserId);
                if (user != null)
                {
                    user.PhotoPath = file.FileName;
                    await _manager.UpdateUserAsync(user);
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
