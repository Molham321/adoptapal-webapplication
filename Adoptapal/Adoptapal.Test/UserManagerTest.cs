/*
 * File: UserManagerTest.cs
 * Namespace: Adoptapal.Test
 * 
 * Description:
 * This file contains the unit tests for the UserManager class, which tests the various
 * methods of the UserManager related to user operations.
 * 
 */

using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Adoptapal.Test
{
    [TestClass]
    public class UserManagerTest
    {
        private UserManager? _userManager;
        private static AdoptapalDbContext? _dbContext;

        private User? user;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AdoptapalDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Adoptapal;Trusted_Connection=True;MultipleActiveResultSets=true");
            _dbContext = new AdoptapalDbContext(optionsBuilder.Options);
            _dbContext.Database.EnsureCreated();
        }

        [TestInitialize]
        public void Initialize()
        {
            _userManager = new UserManager(_dbContext);

            user = new User
            {
                Name = "test",
                Email = "email@gmail.com",
                Password = "12345678Tt."
            };
        }

        [TestMethod]
        public void EmptyConstructorTest()
        {
            var manager = new UserManager(_dbContext);
            Assert.IsInstanceOfType(manager, typeof(UserManager));
            Assert.IsNotNull(manager.GetAllUsersAsync());
        }

        [TestMethod]
        [TestCategory("DB-Logic")]
        [TestProperty("Description", "Add user to db")]
        public async void TestAdd()
        {
            await _userManager.CreateUserAsync(user);
            Assert.IsNotNull(_dbContext.Users.FirstOrDefault(it => it.Name == "test"));
            Assert.IsNotNull(_dbContext.Users.FirstOrDefault(it => it.Email == "email@gmail.com"));
            Assert.IsNotNull(_dbContext.Users.FirstOrDefault(it => it.Password != null));
        }

        [TestMethod]
        [TestCategory("DB-Logic")]
        [TestProperty("Description", "Get user from db by ID")]
        public async void TestGetUserByID()
        {
            await _userManager.CreateUserAsync(user);
            User newUserWithId = await _userManager.GetUserByIdAsync(user.Id);
            User newUserWithId_2 = await _userManager.GetUserByIdAsync(user.Id.ToString());

            Assert.IsInstanceOfType(newUserWithId, typeof(User));
            Assert.IsInstanceOfType(newUserWithId_2, typeof(User));
            Assert.AreEqual(newUserWithId.Id, user.Id);
            Assert.AreEqual(newUserWithId.Name, "test");
            Assert.AreEqual(newUserWithId_2.Name, "test");
        }

        [TestMethod]
        [TestCategory("DB-Logic")]
        [TestProperty("Description", "Get user from db by email")]
        public void TestGetUserByEmail()
        {
            // todo
        }
    }
}
