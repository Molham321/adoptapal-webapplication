/*
 * File: ProfileController.cs
 * Namespace: Adoptapal.Web.Controllers
 * 
 * Description:
 * This file contains the implementation of the ProfileController class, which handles
 * user profile-related actions and displays user information along with their animals.
 * 
 */

using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;
using Adoptapal.Web.FileUploadService;
using Microsoft.AspNetCore.Mvc;

namespace Adoptapal.Web.Controllers
{ 
    public class ProfileController : Controller
    {
        private readonly UserManager _userManager;
        private readonly AnimalManager _animalManager;
        private readonly IFileUploadService _uploadService;

        public static string? UserId;
        public static string? FilePath;
        public ProfileController(UserManager manager, AnimalManager animalManager, IFileUploadService uploadService) : base()
        {
            _userManager = manager;
            _animalManager = animalManager;
            _uploadService = uploadService;
        }
        public IActionResult Index()
        {
            return RedirectToAction("UserProfile");
        }

        public async Task<IActionResult> UserProfile(Guid? id)
        {
            if (id == null)
            {
                UserId = HttpContext.Session.GetString("UserId");
                if(UserId != null)
                {
                    User model = await _userManager.GetUserByIdAsync(UserId);

                    // Get the user's animals
                    List<Animal> userAnimals = await _animalManager.GetAllUserAnimalsByUserAsync(model);
                    int animalCount = userAnimals.Count;

                    ViewBag.AnimalCount = animalCount; // Pass the animal count to the view
                    ViewBag.Animals = userAnimals; // Pass the animal count to the view

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

                // Get the user's animals
                List<Animal> userAnimals = await _animalManager.GetAllUserAnimalsByUserAsync(animal.User);
                int animalCount = userAnimals.Count;

                ViewBag.AnimalCount = animalCount; // Pass the animal count to the view
                ViewBag.Animals = userAnimals; // Pass the animal count to the view


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
                User user = await _userManager.GetUserByIdAsync(UserId);
                if (user != null)
                {
                    user.PhotoPath = file.FileName;
                    await _userManager.UpdateUserAsync(user);
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
