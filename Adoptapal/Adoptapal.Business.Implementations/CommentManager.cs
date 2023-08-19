using Adoptapal.Business.Definitions;
using Microsoft.EntityFrameworkCore;

namespace Adoptapal.Business.Implementations
{
    public class CommentManager
    {
        private readonly AdoptapalDbContext _container;

        public CommentManager(AdoptapalDbContext context)
        {
            _container = context;
            _container.Database.Migrate();
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _container.Comments.Include(it => it.Post).ThenInclude(it => it.User).ToListAsync();
        }

        public async Task<List<Comment>> GetAllPostCommentsByPostAsync(MessageBoard post)
        {
            return await _container.Comments.Where(m => m.Post == post).ToListAsync();
        }

        public async Task<List<Comment>> GetAllUserCommentsByUserAsync(User user)
        {
            return await _container.Comments.Where(m => m.User == user).ToListAsync();
        }

        public async Task<Comment> GetCommentByIdAsync(Guid id)
        {
            return await _container.Comments.Include(it => it.Post).ThenInclude(it => it.User).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateCommentAsync(Comment comment)
        {
            comment.Id = Guid.NewGuid();
            _container.Add(comment);
            await _container.SaveChangesAsync();
        }

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
