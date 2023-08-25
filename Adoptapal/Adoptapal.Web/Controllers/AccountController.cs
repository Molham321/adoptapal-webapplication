/*
 * File: AccountController.cs
 * Namespace: Adoptapal.Web.Controllers
 * 
 * Description:
 * This file contains the implementation of the AccountController class, which handles
 * user account-related actions such as login, registration, password reset, and user settings.
 * 
 */

using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text;
using Adoptapal.Web.Models;

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
            var loginViewModel = new LoginViewModel
            {
                Email = model.Email
            };
            return View("Login", loginViewModel);
        }

        // GET: /Account/ForgotPassword
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
                    var registerViewModel = new RegisterViewModel
                    {
                        Name = model.Name,
                        Email = model.Email,
                    };
                    return View("Register", registerViewModel);
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

        public IActionResult ForgotPassword()
        {
            return View();
        }

        // POST: /Account/ForgotPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            // Validate the email address (you might want to do more thorough validation)
            if (string.IsNullOrWhiteSpace(email))
            {
                ViewData["ErrorMessage"] = "Please provide a valid email address.";
                return View();
            }

            // Generate a unique token (this would be used in the password reset link)
            string resetToken = Guid.NewGuid().ToString();

            // TODO: Save the resetToken in your data store along with the user's email address
            var user = await _manager.FindUserByEmailAsync(email);
            if(user != null)
            {
                user.ResetToken = resetToken;
                await _manager.UpdateUserAsync(user);
            }

            // Send the password reset email
            try
            {
                var smtpClient = new SmtpClient("smtp.example.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("your_username", "your_password"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("from@example.com"),
                    Subject = "Password Reset",
                    Body = $"Click the following link to reset your password: https://example.com/Account/ResetPassword?token={resetToken}"
                };
                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);

                ViewData["Message"] = "Password reset email sent.";
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "An error occurred while sending the email.";
            }

            ViewData["Message"] = "Password reset email sent.";
            return RedirectToAction("ForgotPasswordConfirmation");
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
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

                // update user info
                user.Name = model.Name;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

            if(model.Password != null)
            {
                user.Password = UserManager.HashPassword(model.Password);
            }


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

        [HttpPost]
        public async Task<IActionResult> CheckPassword(string enteredPassword)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false, message = "User not authenticated." });
            }

            User user = await _manager.GetUserByIdAsync(userId);

            if (user == null)
            {
                return Json(new { success = false, message = "User not found." });
            }

            bool isPasswordMatch = UserManager.CheckPassword(user, enteredPassword);

            return Json(new { success = isPasswordMatch });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser()
        {
            if(userId != null)
            {
                User user = await _manager.GetUserByIdAsync(userId);

                if (user != null)
                {
                    await _manager.DeleteUserAsync(user.Id);

                    return RedirectToAction("Signout");
                }

            }

            return RedirectToAction("Login");
        }
    }
}
