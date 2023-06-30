using Adoptapal.Business.Definitions.Config;
using Microsoft.EntityFrameworkCore;

namespace Adoptapal.Business.Definitions
{
    public class AdoptapalDbContext : DbContext
    {
        public AdoptapalDbContext(DbContextOptions<AdoptapalDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // user -----------------
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            // animal ---------------
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Animal> Animals { get; set; }
    }
}
