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
    }
}
