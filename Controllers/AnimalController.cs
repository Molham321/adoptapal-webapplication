using Microsoft.AspNetCore.Mvc;
using adoptapal.Models;
using System;

namespace adoptapal.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            ViewBag.Title = "Tiere";
            return View(Animals);
        }

        public IActionResult Details(Guid id)
        {
            return View(Animals.FirstOrDefault(it => it.Id == id));
        }

        private List<Animal> Animals => new List<Animal>
        {
            new Animal
            {
                Id = new Guid("3c92e546-4733-4fb7-8d29-65553c7dd61f"),
                Name = "Domian",
                Description = "ein neues Tier",
                Birthday = "15.05.2023",
                Supplier = "Anbieter von Domian",
                Category = "Katze",
                MarkedAsFavorite = false,
                Color = "weiß",
                ImagePath = "/",
                IsMale = true,
                Weight = 2.5f,
            },
                        new Animal
            {
                Id = new Guid("6c505a77-0159-4c7d-a292-72aa7fb9a8f8"),
                Name = "Hannelore",
                Description = "ein zweites Tier",
                Birthday = "10.05.2023",
                Supplier = "Anbieter von Hannelore",
                Category = "Hund",
                MarkedAsFavorite = false,
                Color = "blond",
                ImagePath = "/",
                IsMale = false,
                Weight = 4.5f,
            },
        };

    }
}
