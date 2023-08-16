using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;

namespace Adoptapal.Web.Controllers
{
    public class MessageBoardController : Controller
    {
        private readonly MessageBoardManager _manager;
        private readonly UserManager _userManager;
        // private readonly IFileUploadService _uploadService;

        private static string? userId;
        // public static string? FilePath;


        public MessageBoardController(MessageBoardManager manager, UserManager userManager) : base()
        {
            _manager = manager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _manager.GetAllPostsAsync();

            return posts != null ?
                          View(posts) :
                          Problem("Entity set 'AdoptapalDbContext.MessageBoards' is null.");
        }

        // GET: MessageBoard/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MessageBoard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MessageBoard post)
        {
            if (ModelState.IsValid)
            {
                if (userId != null)
                {
                    post.User = await _userManager.GetUserByIdAsync(userId);
                    await _manager.CreatePostAsync(post);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // return RedirectToAction("Login", "Account");
                }
            }

            return View(post);
        }
    }
}
