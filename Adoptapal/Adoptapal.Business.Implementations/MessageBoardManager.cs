using Adoptapal.Business.Definitions;
using Microsoft.EntityFrameworkCore;

namespace Adoptapal.Business.Implementations
{
    public class MessageBoardManager
    {
        private readonly AdoptapalDbContext _container;

        public MessageBoardManager(AdoptapalDbContext context)
        {
            _container = context;
            _container.Database.Migrate();
        }

        public async Task<List<MessageBoard>> GetAllPostsAsync()
        {
            return await _container.MessageBoards.Include(it => it.User).ToListAsync();
        }

        public async Task<List<MessageBoard>> GetAllUserPostsByUserAsync(User user)
        {
            return await _container.MessageBoards.Where(m => m.User == user).ToListAsync();
        }

        public async Task<MessageBoard> GetPostByIdAsync(Guid id)
        {
            return await _container.MessageBoards.Include(it => it.User).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreatePostAsync(MessageBoard messageBoard)
        {
            messageBoard.Id = Guid.NewGuid();
            _container.Add(messageBoard);
            await _container.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(MessageBoard messageBoard)
        {
            _container.Update(messageBoard);
            await _container.SaveChangesAsync();
        }

        public async Task DeletePostAsync(Guid id)
        {
            var messageBoard = await _container.MessageBoards.FindAsync(id);
            if (messageBoard != null)
            {
                _container.MessageBoards.Remove(messageBoard);
                await _container.SaveChangesAsync();
            }
        }

        public bool PostExists(Guid id)
        {
            return (_container.MessageBoards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
