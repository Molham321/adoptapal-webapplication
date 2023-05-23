using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Adoptapal.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager _manager;
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
            return View(new User());
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            // Suche den Benutzer in der Datenbank anhand seiner E-Mail-Adresse
            var user = _manager.FindByEmail(model.Email);
            if (user != null)
            {
                // Überprüfe das Passwort des Benutzers
                if (UserManager.CheckPassword(user, model.Password))
                {
                    // Bei erfolgreicher Anmeldung wird der Benutzer zur Startseite weitergeleitet
                    HttpContext.Session.SetString("UserId", user.Id.ToString()); // Eine Sitzungsvariable erstellen
                    HttpContext.Session.SetString("UserName", user.Email);       // Eine Sitzungsvariable erstellen

                    return RedirectToAction("Index", "Home");
                }
            }

            // Bei fehlerhaften Anmeldeinformationen wird das Anmeldeformular erneut angezeigt
            ModelState.AddModelError("", "Die eingegebenen Anmeldeinformationen sind ungültig.");
            return View(model);
        }



        public IActionResult Register()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _manager.FindByEmail(model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Die eingegebene E-Mail-Adresse ist bereits vergeben.");
                    return View(model);
                }

                model.Password = UserManager.HashPassword(model.Password);
                model.ConfirmPassword = model.Password;

                _manager.Add(model);

                HttpContext.Session.SetString("UserId", model.Id.ToString()); // Eine Sitzungsvariable erstellen
                return RedirectToAction("Index", "Home"); // Weiterleitung zur Startseite
            }

            return View(model); // Wenn das Model ungültig ist, wird es erneut angezeigt
        }

        public IActionResult Signout()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("UserName");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Settings()
        {
            string stringValue = HttpContext.Session.GetString("UserId");
            Guid guidValue;

            bool isValidGuid = Guid.TryParse(stringValue, out guidValue);

            if (isValidGuid)
            {

                User model = _manager.GetUser(guidValue);
                return View(model);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public IActionResult Settings(User model)
        {
            Guid guidValue = model.Id;

            User user = _manager.GetUser(guidValue);

            if (ModelState.IsValid)
            {
                user.Name = model.Name;
                user.Email = model.Email;
                user.Password = UserManager.HashPassword(model.Password);
                user.ConfirmPassword = user.Password;

                _manager.Update(user);

                HttpContext.Session.SetString("UserId", model.Id.ToString()); // Eine Sitzungsvariable erstellen
                return View(model); ; // Weiterleitung zur Startseite
            }

            ModelState.AddModelError("", "error.");
            return View(model); // Wenn das Model ungültig ist, wird es erneut angezeigt
        }
    }
}
