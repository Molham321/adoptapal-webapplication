/*
 * File: CommentController.cs
 * Namespace: Adoptapal.Web.Controllers
 * 
 * Description:
 * This file contains the implementation of the CommentController class, which handles
 * actions related to comments on message board posts.
 * 
 */

using Microsoft.AspNetCore.Mvc;
using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;

namespace Adoptapal.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentManager _manager;

        public CommentController(CommentManager manager) : base()
        {
            _manager = manager;
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
