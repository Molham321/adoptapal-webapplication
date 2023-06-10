﻿using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Adoptapal.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager _manager;
        private static string? userId;
        public AccountController(UserManager manager) : base()
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User model)
        {
            // Suche den Benutzer in der Datenbank anhand seiner E-Mail-Adresse
            var user = await _manager.FindUserByEmailAsync(model.Email);
            if (user != null)
            {
                // Überprüfe das Passwort des Benutzers
                if (UserManager.CheckPassword(user, model.Password))
                {
                    // Bei erfolgreicher Anmeldung wird der Benutzer zur Startseite weitergeleitet
                    HttpContext.Session.SetString("UserId", user.Id.ToString()); // Eine Sitzungsvariable erstellen

                    return RedirectToAction("Index", "Home");
                }
            }

            // Bei fehlerhaften Anmeldeinformationen wird das Anmeldeformular erneut angezeigt
            ModelState.AddModelError("", "Die eingegebenen Anmeldeinformationen sind ungültig.");
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _manager.FindUserByEmailAsync(model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Die eingegebene E-Mail-Adresse ist bereits vergeben.");
                    return View(model);
                }

                model.Password = UserManager.HashPassword(model.Password);

                await _manager.CreateUserAsync(model);

                HttpContext.Session.SetString("UserId", model.Id.ToString()); // Eine Sitzungsvariable erstellen
                return RedirectToAction("Index", "Home"); // Weiterleitung zur Startseite
            }

            return View(model); // Wenn das Model ungültig ist, wird es erneut angezeigt
        }

        public IActionResult Signout()
        {
            HttpContext.Session.Remove("UserId");

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Settings()
        {
            userId = HttpContext.Session.GetString("UserId");

            if (userId != null)
            {
                User model = await _manager.GetUserByIdAsync(userId);
                return View(model);
            }
             return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Settings(User model)
        {
            User user = await _manager.GetUserByIdAsync(model.Id);

            //check validation
            if (ModelState.IsValid)
            {
                // update user info
                user.Name = model.Name;
                user.Email = model.Email;
                user.Password = UserManager.HashPassword(model.Password);
                user.PhoneNumber = model.PhoneNumber;


                // Add or update user address
                if (user.Address == null)
                {
                    Address address = new Address
                    {
                        Street = model.Address.Street,
                        StreetNumber = model.Address.StreetNumber,
                        City = model.Address.City,
                        Zip = model.Address.Zip
                    };

                    user.Address = address;
                    await _manager.AddAddressAsync(address);

                }
                else
                {
                    user.Address.Street = model.Address.Street;
                    user.Address.StreetNumber = model.Address.StreetNumber;
                    user.Address.City = model.Address.City;
                    user.Address.Zip = model.Address.Zip;
                }

                // update DB
                await _manager.UpdateUserAsync(user);

                HttpContext.Session.SetString("UserId", model.Id.ToString()); // Eine Sitzungsvariable erstellen

                return View(model);
            }

            ModelState.AddModelError("", "Is not Valid.");
            return View(model); // Wenn das Model ungültig ist, wird es erneut angezeigt
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser()
        {
            User user = await _manager.GetUserByIdAsync(userId);

            if(user != null)
            {
                await _manager.DeleteUserAsync(user.Id);

                return RedirectToAction("Signout");
            }
            return RedirectToAction("Login");

        }
    }
}
