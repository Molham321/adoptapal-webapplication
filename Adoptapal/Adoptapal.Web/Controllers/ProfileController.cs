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
using Microsoft.Extensions.Hosting;

namespace Adoptapal.Web.Controllers
{ 
    public class ProfileController : Controller
    {
        private readonly UserManager _userManager;
        private readonly AnimalManager _animalManager;
        private readonly MessageBoardManager _messageBoardManager;
        private readonly IFileUploadService _uploadService;

        public static string? UserId;
        public static string? FilePath;
        public ProfileController(UserManager manager, AnimalManager animalManager, MessageBoardManager messageBoardManager, IFileUploadService uploadService) : base()
        {
            _userManager = manager;
            _animalManager = animalManager;
            _messageBoardManager = messageBoardManager;
            _uploadService = uploadService;
        }
        public IActionResult Index()
        {
            return RedirectToAction("UserProfile");
        }

        public async Task<IActionResult> UserProfile(Guid? id)
        {
            // hier dritten Fall, für Userprofil aufrufen aus Post (Schwarzes Brett)
            // MessageBoard manager benötigt

            if (id == null)
            {
                UserId = HttpContext.Session.GetString("UserId");
                if(UserId != null)
                {
                    User model = await _userManager.GetUserByIdAsync(UserId);

                    // Get the user's animals
                    List<Animal> userAnimals = await _animalManager.GetAllUserAnimalsByUserAsync(model);
                    int animalCount = userAnimals.Count;

                    // Get the user's posts
                    List<MessageBoard> userPosts = await _messageBoardManager.GetAllUserPostsByUserAsync(model);

                    ViewBag.AnimalCount = animalCount; // Pass the animal list to the view
                    ViewBag.Animals = userAnimals; // Pass the animal count to the view
                    ViewBag.MessageBoards = userPosts; // Pass the post list to the view

                    return View(model);

                } else
                {
                    return RedirectToAction("Login", "AccountController");
                }
            } else
            {
                // get user from an animal (clicked on animal in home screen) or...
                var animal = await _animalManager.GetAnimalByIdAsync(id.Value);
                if (animal == null)
                {
                    // ...get user from a post (clicked on post on message board screen)
                    var post = await _messageBoardManager.GetPostByIdAsync(id.Value);

                    if (post == null)
                    {
                        return NotFound();
                    }

                    List<Animal> userAnimals = await _animalManager.GetAllUserAnimalsByUserAsync(post.User);
                    int animalCount = userAnimals.Count;
                    List<MessageBoard> userPosts = await _messageBoardManager.GetAllUserPostsByUserAsync(post.User);

                    ViewBag.AnimalCount = animalCount;
                    ViewBag.Animals = userAnimals;
                    ViewBag.MessageBoards = userPosts;

                    return View(post.User);
                }
                else
                {
                    // Get the user's animals
                    List<Animal> userAnimals = await _animalManager.GetAllUserAnimalsByUserAsync(animal.User);
                    int animalCount = userAnimals.Count;
                    List<MessageBoard> userPosts = await _messageBoardManager.GetAllUserPostsByUserAsync(animal.User);

                    ViewBag.AnimalCount = animalCount; // Pass the animal list to the view
                    ViewBag.Animals = userAnimals; // Pass the animal count to the view
                    ViewBag.MessageBoards = userPosts; // Pass the post list to the view


                    return View(animal.User);
                }
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
