/*
 * File: UserManager.cs
 * Namespace: Adoptapal.Business.Implementations
 * 
 * Description:
 * This file contains the implementation of the UserManager class responsible for managing
 * operations related to user entities. It includes methods for CRUD operations on users,
 * retrieval of user data, password hashing, and checking for the existence of a user.
 * 
 */

using Adoptapal.Business.Definitions;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Adoptapal.Business.Implementations
{
    /// <summary>
    /// Manager class for managing operations related to user entities.
    /// </summary>
    public class UserManager
    {
        private readonly AdoptapalDbContext _container;

        /// <summary>
        /// Initializes a new instance of the UserManager class.
        /// </summary>
        /// <param name="context">The database context instance.</param>
        public UserManager(AdoptapalDbContext context)
        {
            _container = context;
            _container.Database.Migrate();
        }

        /// <summary>
        /// Retrieves a list of all users asynchronously, including associated address information.
        /// </summary>
        /// <returns>A list of users.</returns>
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _container.Users.Include(it => it.Address).ToListAsync();
        }

        /// <summary>
        /// Retrieves a user by their unique identifier asynchronously, including associated address information.
        /// </summary>
        /// <param name="id">The unique identifier of the user to retrieve.</param>
        /// <returns>The user entity.</returns>
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _container.Users.Include(it => it.Address).FirstOrDefaultAsync(it => it.Id == id);
        }

        /// <summary>
        /// Retrieves a user by their unique identifier (string) asynchronously, including associated address information.
        /// </summary>
        /// <param name="userId">The unique identifier (string) of the user to retrieve.</param>
        /// <returns>The user entity.</returns>
        public async Task<User> GetUserByIdAsync(string userId)
        {
            Guid.TryParse(userId, out Guid id);
            return await _container.Users.Include(it => it.Address).FirstOrDefaultAsync(it => it.Id == id);
        }

        /// <summary>
        /// Finds a user by their email address asynchronously, including associated address information.
        /// </summary>
        /// <param name="email">The email address of the user to find.</param>
        /// <returns>The user entity.</returns>
        public async Task<User> FindUserByEmailAsync(string email)
        {
            return await _container.Users.Include(it => it.Address).FirstOrDefaultAsync(it => it.Email == email);
        }

        /// <summary>
        /// Checks if a provided password matches the hashed password of a user.
        /// </summary>
        /// <param name="user">The user entity.</param>
        /// <param name="password">The password to check.</param>
        /// <returns>True if the password is correct; otherwise, false.</returns>
        public static bool CheckPassword(User user, string password)
        {
            password = HashPassword(password);
            return user.Password == password;
        }

        /// <summary>
        /// Hashes a password using SHA-256 encryption.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hashed password.</returns>
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", string.Empty);
            }
        }

        /// <summary>
        /// Creates a new user asynchronously.
        /// </summary>
        /// <param name="user">The user entity to create.</param>
        public async Task CreateUserAsync(User user)
        {
            user.Id = Guid.NewGuid();
            _container.Add(user);
            await _container.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a new address asynchronously.
        /// </summary>
        /// <param name="address">The address entity to add.</param>
        public async Task AddAddressAsync(Address address)
        {
            address.Id = Guid.NewGuid();
            _container.Add(address);
            await _container.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a user asynchronously, including associated address information if available.
        /// </summary>
        /// <param name="user">The user entity to update.</param>
        public async Task UpdateUserAsync(User user)
        {
            if (user.Address != null)
            {
                _container.Update(user.Address);
            }

            _container.Update(user);
            await _container.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a user by their unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete.</param>
        public async Task DeleteUserAsync(Guid id)
        {

            // Remove the animal from user first
            var userAnimalsToDelete = await _container.Animals
                .Where(f => f.User.Id == id)
                .ToListAsync();

            foreach (var userAnimals in userAnimalsToDelete)
            {
                _container.Animals.Remove(userAnimals);
            }

            var user = await _container.Users.FindAsync(id);
            if (user != null)
            {
                _container.Users.Remove(user);
                await _container.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Checks if a user exists based on their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        public bool UserExists(Guid id)
        {
            return _container.Users.Any(e => e.Id == id);
        }
    }
}
