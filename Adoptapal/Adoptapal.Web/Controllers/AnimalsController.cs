using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;
using Adoptapal.Web.FileUploadService;

namespace Adoptapal.Web.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly AnimalManager _manager;
        private readonly UserManager _userManager;
        private readonly IFileUploadService _uploadService;

        private static string? userId;
        public static string? FilePath;


        public AnimalsController(AnimalManager manager, UserManager userManager, IFileUploadService uploadService) : base()
        {
            _manager = manager;
            _userManager = userManager;
            _uploadService = uploadService;
        }

        // GET: Animals
        public async Task<IActionResult> Index()
        {
            userId = HttpContext.Session.GetString("UserId");

            if(userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var animals = await _manager.GetAllUserAnimalsByUserAsync(await _userManager.GetUserByIdAsync(userId));

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

        // GET: Animals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Animal animal, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                if (userId != null)
                {
                    if (file != null)
                    {
                        FilePath = await _uploadService.UploadFileAsync(file);
                        animal.ImageFilePath = file.FileName;

                    }

                    animal.User = await _userManager.GetUserByIdAsync(userId);
                    await _manager.CreateAnimalAsync(animal);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }

            return View(animal);
        }


        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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

        // POST: Animals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Animal animal, IFormFile? file)
        {
            if (id != animal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    FilePath = await _uploadService.UploadFileAsync(file);
                    animal.ImageFilePath = file.FileName;

                }

                try
                {
                    await _manager.UpdateAnimalAsync(animal);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_manager.AnimalExists(animal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
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

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _manager.DeleteAnimalAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
