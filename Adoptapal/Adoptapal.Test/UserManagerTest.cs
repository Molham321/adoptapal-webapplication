using Adoptapal.Business.Definitions;
using Adoptapal.Business.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Adoptapal.Test
{
    [TestClass]
    public class UserManagerTest
    {
        private UserManager _userManager;
        private static AdoptapalDbContext _dbContext;

        private User user;

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
            Assert.IsNotNull(manager.GetList());
        }

        [TestMethod]
        [TestCategory("DB-Logic")]
        [TestProperty("Description", "Add user to db")]
        public void TestAdd()
        {
            _userManager.Add(user);
            Assert.IsNotNull(_dbContext.Users.FirstOrDefault(it => it.Name == "test"));
            Assert.IsNotNull(_dbContext.Users.FirstOrDefault(it => it.Email == "email@gmail.com"));
            Assert.IsNotNull(_dbContext.Users.FirstOrDefault(it => it.Password != null));
        }

        [TestMethod]
        [TestCategory("DB-Logic")]
        [TestProperty("Description", "Get user from db by ID")]
        public void TestGetUserByID()
        {
            _userManager.Add(user);
            User newUserWithId = _userManager.GetUser(user.Id);
            User newUserWithId_2 = _userManager.GetUser(user.Id.ToString());

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
