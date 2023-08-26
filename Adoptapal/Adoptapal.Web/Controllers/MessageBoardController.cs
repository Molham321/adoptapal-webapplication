/*
 * File: MessageBoardController.cs
 * Namespace: Adoptapal.Web.Controllers
 * 
 * Description:
 * This file contains the implementation of the MessageBoardController class, which handles
 * various actions related to message board posts and comments.
 * 
 */

using Microsoft.AspNetCore.Mvc;
using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;

namespace Adoptapal.Web.Controllers
{
    public class MessageBoardController : Controller
    {
        private readonly MessageBoardManager _manager;
        private readonly UserManager _userManager;
        private readonly CommentManager _commentManager;
        // private readonly IFileUploadService _uploadService;

        private static string? userId;
        private static Guid currentPostId;
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

            // HttpContext.Session.SetString("currentPostId", post.Id.ToString());

            currentPostId = post.Id;

            return View(post);
        }

        //GET: Comment/Create/Id
        public async Task<IActionResult> CreateComment(Guid? currentPost)
        {
            if (currentPost == null)
            {
                return NotFound();
            }

            userId = HttpContext.Session.GetString("UserId");

            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCommentConfirmed(Comment comment)
        {
            userId = HttpContext.Session.GetString("UserId");

            if (ModelState.IsValid)
            {
                comment.Post = await _manager.GetPostByIdAsync(currentPostId);
                comment.User = await _userManager.GetUserByIdAsync(userId);
                comment.PostTime = DateTime.Now;
                await _commentManager.CreateCommentAsync(comment);
                return RedirectToAction("Details", new { id = currentPostId });
            }

            return View(comment);
        }

        // GET: Comments
        public async Task<IActionResult> PostComments(Guid? id)
        {
            userId = HttpContext.Session.GetString("UserId");

            var post = await _manager.GetPostByIdAsync(id.Value);

            var commentsByPost = await _commentManager.GetAllPostCommentsByPostAsync(post);

            return commentsByPost != null ?
                                   View(commentsByPost) :
                                   Problem("Entity set 'AdoptapalDbContext.Comments' is null.");
        }

        // DELETE: Comment/Id
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            await _commentManager.DeleteCommentAsync(id);
            return RedirectToAction("PostComments", new { id = currentPostId });
        }
    }
}
