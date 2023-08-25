using Adoptapal.Business.Definitions.Config;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

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
                PhoneNumber = "+1234567890"
            };

            var testUser2 = new User
            {
                Id = Guid.NewGuid(),
                Name = "Jane Smith",
                Email = "jane@example.com",
                Password = "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345",
                PhoneNumber = "+9876543210"
            };

            var testUser3 = new User
            {
                Id = Guid.NewGuid(),
                Name = "Michael Johnson",
                Email = "michael@example.com",
                Password = "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345",
                PhoneNumber = "+1543216789"
            };

            var testUser4 = new User
            {
                Id = Guid.NewGuid(),
                Name = "Emily Brown",
                Email = "emily@example.com",
                Password = "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345",
                PhoneNumber = "+1122334455"
            };

            testUser1.Address = newAddress;
            testUser2.Address = newAddress;
            testUser3.Address = newAddress;
            testUser4.Address = newAddress;

            modelBuilder.Entity<User>().HasData(testUser1);
            modelBuilder.Entity<User>().HasData(testUser2);
            modelBuilder.Entity<User>().HasData(testUser3);
            modelBuilder.Entity<User>().HasData(testUser4);

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
                ImageFilePath = "path/to/animal2.jpg",
            };

            var testAnimal3 = new Animal
            {
                Id = Guid.NewGuid(),
                Name = "Buddy",
                Birthday = new DateTime(2018, 9, 20),
                AnimalCategory = "Dog",
                Description = "A loyal and energetic dog",
                Color = "Golden",
                IsMale = true,
                Weight = 20.0f,
                ImageFilePath = "path/to/animal3.jpg",
            };

            var testAnimal4 = new Animal
            {
                Id = Guid.NewGuid(),
                Name = "Mittens",
                Birthday = new DateTime(2022, 4, 5),
                AnimalCategory = "Cat",
                Description = "A playful and adorable kitten",
                Color = "Calico",
                IsMale = false,
                Weight = 3.5f,
                ImageFilePath = "path/to/animal4.jpg",
            };

            testAnimal1.User = testUser1;
            testAnimal2.User = testUser2;
            testAnimal3.User = testUser3;
            testAnimal4.User = testUser4;

            modelBuilder.Entity<Animal>().HasData(testAnimal1);
            modelBuilder.Entity<Animal>().HasData(testAnimal2);
            modelBuilder.Entity<Animal>().HasData(testAnimal3);
            modelBuilder.Entity<Animal>().HasData(testAnimal4);
        }
    }
}
