/*
 * File: CommentManager.cs
 * Namespace: Adoptapal.Business.Implementations
 * 
 * Description:
 * This file contains the implementation of the CommentManager class responsible for managing
 * operations related to comment entities. It includes methods for CRUD operations on comments,
 * retrieval of comment data, and checking for the existence of a comment.
 * 
 */

using Adoptapal.Business.Definitions;
using Microsoft.EntityFrameworkCore;

namespace Adoptapal.Business.Implementations
{
    /// <summary>
    /// Manager class for managing operations related to comment entities.
    /// </summary>
    public class CommentManager
    {
        private readonly AdoptapalDbContext _container;

        /// <summary>
        /// Initializes a new instance of the CommentManager class.
        /// </summary>
        /// <param name="context">The database context instance.</param>
        public CommentManager(AdoptapalDbContext context)
        {
            _container = context;
            _container.Database.Migrate();
        }

        /// <summary>
        /// Retrieves a list of all comments asynchronously, including associated post and user information.
        /// </summary>
        /// <returns>A list of comments.</returns>
        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _container.Comments.Include(it => it.Post).Include(it => it.User).ToListAsync();
        }

        /// <summary>
        /// Retrieves a list of all comments associated with a specific post asynchronously.
        /// </summary>
        /// <param name="post">The post for which to retrieve comments.</param>
        /// <returns>A list of comments associated with the post.</returns>
        public async Task<List<Comment>> GetAllPostCommentsByPostAsync(MessageBoard post)
        {
            return await _container.Comments.Include(it => it.User).Where(m => m.Post == post).ToListAsync();
        }

        /// <summary>
        /// Retrieves a list of all comments associated with a specific user asynchronously.
        /// </summary>
        /// <param name="user">The user for whom to retrieve comments.</param>
        /// <returns>A list of comments associated with the user.</returns>
        public async Task<List<Comment>> GetAllUserCommentsByUserAsync(User user)
        {
            return await _container.Comments.Where(m => m.User == user).ToListAsync();
        }

        /// <summary>
        /// Retrieves a comment by its unique identifier asynchronously, including associated post and user information.
        /// </summary>
        /// <param name="id">The unique identifier of the comment to retrieve.</param>
        /// <returns>The comment entity.</returns>
        public async Task<Comment> GetCommentByIdAsync(Guid id)
        {
            return await _container.Comments.Include(it => it.Post).Include(it => it.User).FirstOrDefaultAsync(m => m.Id == id);
        }

        /// <summary>
        /// Creates a new comment asynchronously.
        /// </summary>
        /// <param name="comment">The comment entity to create.</param>
        public async Task CreateCommentAsync(Comment comment)
        {
            comment.Id = Guid.NewGuid();
            _container.Add(comment);
            await _container.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a comment by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the comment to delete.</param>
        public async Task DeleteCommentAsync(Guid id)
        {
            var comment = await _container.Comments.FindAsync(id);
            if (comment != null)
            {
                _container.Comments.Remove(comment);
                await _container.SaveChangesAsync();
            }
        }
    }
}
