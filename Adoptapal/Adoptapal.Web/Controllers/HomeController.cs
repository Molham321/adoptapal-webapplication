﻿using Adoptapal.Business.Implementations;
using Adoptapal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace Adoptapal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AnimalManager _manager;
        private readonly UserManager _userManager;

        public static string? UserId;

        public HomeController(AnimalManager manager, UserManager userManager) : base()
        {
            _manager = manager;
            _userManager = userManager;
        }

        public async Task<IActionResult> AddToFavorite(Guid animalId)
        {
            var animal = await _manager.GetAnimalByIdAsync(animalId);
            if (animal == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserByIdAsync(UserId);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Register");
            }

            await _userManager.AddFavoriteAnimalAsync(currentUser, animal);

            return RedirectToAction("Index");
        }

        // GET: Animals
        public async Task<IActionResult> Index(string AnimalCategory, bool? IsMale, DateTime? Birthday)
        {
            UserId = HttpContext.Session.GetString("UserId");

            var allAnimals = await _manager.GetAllAnimalsAsync();

            ViewData["IsMaleValue"] = IsMale;

            var animals = from b in allAnimals select b;

            if (!String.IsNullOrEmpty(AnimalCategory))
            {
                ViewData["AnimalCategoryFilter"] = AnimalCategory;
                animals = animals.Where(b => b.AnimalCategory.Contains(AnimalCategory));
            }

            if (IsMale.HasValue)
            {

                if (IsMale == true)
                {
                    ViewData["IsMaleFilter"] = "Male";
                }
                else
                {
                    ViewData["IsMaleFilter"] = "Female";
                }

                animals = animals.Where(b => b.IsMale == IsMale.Value);
            }

            if (Birthday.HasValue)
            {
                ViewData["BirthdayFilter"] = Birthday?.ToString("yyyy-MM-dd");
                animals = animals.Where(b => b.Birthday >= Birthday.Value && b.Birthday <= DateTime.Today);
            }

            return animals != null ?
                          View(animals) :
                          Problem("Entity set 'AdoptapalDbContext.Animals' is null.");
        }

        // GET: User/Profile/5
        public async Task<IActionResult> UserProfile(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _manager.GetAnimalByIdAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal.User);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}