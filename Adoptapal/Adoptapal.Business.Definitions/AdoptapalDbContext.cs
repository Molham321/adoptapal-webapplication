
/*
 * File: AdoptapalDbContext.cs
 * Namespace: Adoptapal.Business.Definitions
 * 
 * Description:
 * This file contains the definition of the DbContext class "AdoptapalDbContext". It represents
 * the database context for the Adoptapal application and includes DbSet properties for each
 * entity, as well as the configuration of these entities through the Fluent API.
 * It also includes a static method for seeding initial data.
 * 
 */

using Adoptapal.Business.Definitions.Config;
using Microsoft.EntityFrameworkCore;

namespace Adoptapal.Business.Definitions
{
    /// <summary>
    /// Represents the database context for the Adoptapal application.
    /// </summary>
    public class AdoptapalDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<MessageBoard> MessageBoards { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FavoritAnimals> FavoritAnimals { get; set; }

        public AdoptapalDbContext(DbContextOptions<AdoptapalDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Configures the entity relationships and model using the Fluent API.
        /// </summary>
        /// <param name="modelBuilder">The model builder instance.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure entity relationships using entity configurations
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new MessageBoardConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new FavoritAnimalsConfiguration());

            SeedData(modelBuilder); // Call the seed data method

            base.OnModelCreating(modelBuilder);
        }

        public static void SeedData(ModelBuilder modelBuilder)
        {
            var newAddress = new Address
            {
                Id = Guid.NewGuid(),
                Street = "Main St",
                StreetNumber = "1",
                City = "Sample City",
                Zip = "12345",
                Lat = 37.7749,
                Long = -122.4194
            };

            modelBuilder.Entity<Address>().HasData(newAddress);

            var testUser1 = new User
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                Email = "john@example.com",
                Password = "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345",
                PhoneNumber = "+1234567890",
            };

            var testUser2 = new User
            {
                Id = Guid.NewGuid(),
                Name = "Jane Smith",
                Email = "jane@example.com",
                Password = "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345",
                PhoneNumber = "+9876543210",
            };

            modelBuilder.Entity<User>().HasData(testUser1, testUser2);

            var testAnimal1 = new Animal
            {
                Id = Guid.NewGuid(),
                Name = "Fluffy",
                Birthday = new DateTime(2019, 5, 15),
                AnimalCategory = "Dog",
                Description = "A cute and friendly dog",
                Color = "White",
                IsMale = true,
                Weight = 15.5f,
                ImageFilePath = "path/to/animal1.jpg"
            };

            var testAnimal2 = new Animal
            {
                Id = Guid.NewGuid(),
                Name = "Whiskers",
                Birthday = new DateTime(2020, 2, 10),
                AnimalCategory = "Cat",
                Description = "A playful and curious cat",
                Color = "Gray",
                IsMale = false,
                Weight = 8.2f,
                ImageFilePath = "path/to/animal2.jpg"
            };

            modelBuilder.Entity<Animal>().HasData(testAnimal1, testAnimal2);
        }
    }
}
