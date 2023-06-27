using Adoptapal.Business.Implementations;
using Adoptapal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Adoptapal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AnimalManager _manager;


        public HomeController(AnimalManager manager) : base()
        {
            _manager = manager;
        }

        // GET: Animals
        public async Task<IActionResult> Index()
        {
            var animals = await _manager.GetAllAnimalsAsync();

            return animals != null ?
                          View(animals) :
                          Problem("Entity set 'AdoptapalDbContext.Animals' is null.");
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _manager.GetAnimalByIdAsync(id.Value);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
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