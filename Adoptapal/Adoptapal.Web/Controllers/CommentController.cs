using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;
using Microsoft.Extensions.Hosting;

namespace Adoptapal.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentManager _manager;
        private readonly UserManager _userManager;
        private readonly MessageBoardManager _messageBoardManager;

        private static string? userId;

        public CommentController(CommentManager manager, UserManager userManager, MessageBoardManager commentManager) : base()
        {
            _manager = manager;
            _userManager = userManager;
            _messageBoardManager = commentManager;
        }

        // GET: Comments
        public async Task<IActionResult> PostComments(MessageBoard post)
        {
            var commentsByPost = await _manager.GetAllPostCommentsByPostAsync(post);

            return commentsByPost != null ?
                                   View(commentsByPost) :
                                   Problem("Entity set 'AdoptapalDbContext.MessageBoards' is null.");
        }
    }
}
