using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Adoptapal.Web.Controllers
{
    public class NoticeController : Controller
    {
        private readonly NoticeManager _manager;
        public NoticeController(NoticeManager manager) : base()
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            return View(_manager.GetList().ToList());
        }

        public IActionResult Create()
        {
            return View(new Notice());
        }

        [HttpPost]
        public IActionResult Create(Notice model)
        {
            if (ModelState.IsValid)
            {
                _manager.Add(model);
                return RedirectToAction("List");
            }
            return View(model);
        }

        public IActionResult Details(Guid id)
        {
            return View(_manager.Get(id));
        }

        public IActionResult Delete(Guid id)
        {
            _manager.Delete(id);
            return RedirectToAction("List");
        }
    }
}
