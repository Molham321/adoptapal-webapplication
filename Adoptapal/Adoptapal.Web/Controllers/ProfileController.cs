using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Adoptapal.Web.Controllers
{ 
    public class ProfileController : Controller
    {
        private readonly UserManager _manager;
        public ProfileController(UserManager manager) : base()
        {
            _manager = manager;
        }
        public IActionResult Index(User user)
        {
            return RedirectToAction("UserProfile");
        }

        public IActionResult UserProfile(User user)
        {
            string stringValue = HttpContext.Session.GetString("UserId");
            Guid guidValue;

            bool isValidGuid = Guid.TryParse(stringValue, out guidValue);

            if (isValidGuid)
            {
                User model = _manager.GetUser(guidValue);
                return View(model);
            }
            return RedirectToAction("Login", "AccountController");
        }
    }
}
