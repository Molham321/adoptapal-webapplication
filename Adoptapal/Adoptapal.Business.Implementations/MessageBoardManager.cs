/*
 * File: MessageBoardManager.cs
 * Namespace: Adoptapal.Business.Implementations
 * 
 * Description:
 * This file contains the implementation of the MessageBoardManager class responsible for managing
 * operations related to message board (post) entities. It includes methods for CRUD operations on posts,
 * retrieval of post data, and checking for the existence of a post.
 * 
 */

using Adoptapal.Business.Definitions;
using Microsoft.EntityFrameworkCore;

namespace Adoptapal.Business.Implementations
{
    /// <summary>
    /// Manager class for managing operations related to message board (post) entities.
    /// </summary>
    public class MessageBoardManager
    {
        private readonly AdoptapalDbContext _container;

        /// <summary>
        /// Initializes a new instance of the MessageBoardManager class.
        /// </summary>
        /// <param name="context">The database context instance.</param>
        public MessageBoardManager(AdoptapalDbContext context)
        {
            _container = context;
            _container.Database.Migrate();
        }

        /// <summary>
        /// Retrieves a list of all posts asynchronously, including associated user information.
        /// </summary>
        /// <returns>A list of posts.</returns>
        public async Task<List<MessageBoard>> GetAllPostsAsync()
        {
            return await _container.MessageBoards.Include(it => it.User).ToListAsync();
        }

        /// <summary>
        /// Retrieves a list of all posts associated with a specific user asynchronously.
        /// </summary>
        /// <param name="user">The user for whom to retrieve posts.</param>
        /// <returns>A list of posts associated with the user.</returns>
        public async Task<List<MessageBoard>> GetAllUserPostsByUserAsync(User user)
        {
            return await _container.MessageBoards.Where(m => m.User == user).ToListAsync();
        }

        /// <summary>
        /// Retrieves a post by its unique identifier asynchronously, including associated user information.
        /// </summary>
        /// <param name="id">The unique identifier of the post to retrieve.</param>
        /// <returns>The post entity.</returns>
        public async Task<MessageBoard> GetPostByIdAsync(Guid id)
        {
            return await _container.MessageBoards.Include(it => it.User).FirstOrDefaultAsync(m => m.Id == id);
        }

        /// <summary>
        /// Creates a new post asynchronously.
        /// </summary>
        /// <param name="messageBoard">The post entity to create.</param>
        public async Task CreatePostAsync(MessageBoard messageBoard)
        {
            messageBoard.Id = Guid.NewGuid();
            _container.Add(messageBoard);
            await _container.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a post asynchronously.
        /// </summary>
        /// <param name="messageBoard">The post entity to update.</param>
        public async Task UpdatePostAsync(MessageBoard messageBoard)
        {
            _container.Update(messageBoard);
            await _container.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a post by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the post to delete.</param>
        public async Task DeletePostAsync(Guid id)
        {
            var messageBoard = await _container.MessageBoards.FindAsync(id);
            if (messageBoard != null)
            {
                _container.MessageBoards.Remove(messageBoard);
                await _container.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Checks if a post exists based on its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the post to check.</param>
        /// <returns>True if the post exists; otherwise, false.</returns>
        public bool PostExists(Guid id)
        {
            return (_container.MessageBoards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
