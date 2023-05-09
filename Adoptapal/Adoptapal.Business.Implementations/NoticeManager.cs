using Adoptapal.Business.Definitions;
using Microsoft.EntityFrameworkCore;

namespace Adoptapal.Business.Implementations
{
    public class NoticeManager
    {
        private readonly AdoptapalDbContext _container;

        public NoticeManager(AdoptapalDbContext context)
        {
            _container = context;
            // Nicht mehr State of the art bei Containerisierung/Orchestrierung, aber bei Einzelapplikationen noch geeignet
            _container.Database.Migrate();
        }

        public IQueryable<Notice> GetList()
        {
            return _container.Notices.AsQueryable();
        }

        public Notice? Get(Guid id)
        {
            return _container.Notices.Find(id);
        }

        public void Add(Notice notice)
        {
            notice.Id = Guid.NewGuid();
            _container.Notices.Add(notice);
            _container.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var notice = _container.Notices.FirstOrDefault(x => x.Id == id);
            if (notice != null)
            {
                _container.Notices.Remove(notice);
                _container.SaveChanges();
            }
        }
    }
}
