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

            // messageBoard ---------
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());

            // comment --------------
            modelBuilder.ApplyConfiguration(new CommentConfiguration());

            // comment --------------
            modelBuilder.ApplyConfiguration(new FavoritAnimalsConfiguration());

            SeedData(modelBuilder); // Hier aufrufen

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<MessageBoard> MessageBoards { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FavoritAnimals> FavoritAnimals { get; set; }

        public static void SeedData(ModelBuilder modelBuilder)
        {
            var addresses = new[]
            {
                new Address
                {
                    Id = Guid.NewGuid(),
                    Street = "123 Main St",
                    StreetNumber = "1",
                    City = "Sample City",
                    Zip = "12345",
                    Lat = 37.7749, // Example latitude
                    Long = -122.4194 // Example longitude
                },
                // Add other addresses as needed
            };

            modelBuilder.Entity<Address>().HasData(addresses);


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    Email = "john@example.com",
                    Password = "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345",
                    PhoneNumber = "+1234567890",
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Jane Smith",
                    Email = "jane@example.com",
                    Password = "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345",
                    PhoneNumber = "+9876543210",
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Michael Johnson",
                    Email = "michael@example.com",
                    Password = "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345",
                    PhoneNumber = "+1543216789",
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Emily Brown",
                    Email = "emily@example.com",
                    Password = "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345",
                    PhoneNumber = "+1122334455",
                }
                );
        }
    }
}
