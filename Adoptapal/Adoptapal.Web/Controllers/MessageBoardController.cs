using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;
using Microsoft.Extensions.Hosting;
using Adoptapal.Web.Models;

namespace Adoptapal.Web.Controllers
{
    public class MessageBoardController : Controller
    {
        private readonly MessageBoardManager _manager;
        private readonly UserManager _userManager;
        private readonly CommentManager _commentManager;
        // private readonly IFileUploadService _uploadService;

        private static string? userId;
        // public static string? FilePath;


        public MessageBoardController(MessageBoardManager manager, UserManager userManager, CommentManager commentManager) : base()
        {
            _manager = manager;
            _userManager = userManager;
            _commentManager = commentManager;
        }

        // GET: MessageBoards
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
            userId = HttpContext.Session.GetString("UserId");

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
                    post.PostTime = DateTime.Now;
                    // Console.Write(post);
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

        // GET: MessageBoard/Delete/ID
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _manager.GetPostByIdAsync(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: MessageBoard/Delete/ID
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _manager.DeletePostAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MessageBoards/Details/ID
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _manager.GetPostByIdAsync(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(Comment comment, Guid postId)
        {
            if (ModelState.IsValid)
            {
                if (userId != null)
                {
                    comment.Post = await _manager.GetPostByIdAsync(postId);
                    comment.User = await _userManager.GetUserByIdAsync(userId);
                    comment.PostTime = DateTime.Now;
                    // Console.Write(post);
                    await _commentManager.CreateCommentAsync(comment);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // return RedirectToAction("Login", "Account");
                }
            }

            return View(comment);
        }

        // GET: Comments
        public async Task<IActionResult> PostComments(MessageBoard post)
        {
            var commentsByPost = await _commentManager.GetAllPostCommentsByPostAsync(post);

            return commentsByPost != null ?
                                   View(commentsByPost) :
                                   Problem("Entity set 'AdoptapalDbContext.Comments' is null.");
        }
    }
}
