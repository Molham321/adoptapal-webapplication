
using Adoptapal.Business.Definitions;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;

namespace Adoptapal.Business.Implementations
{
    public class UserManager
    {
        private readonly AdoptapalDbContext _container;

        public UserManager(AdoptapalDbContext context)
        {
            _container = context;
            _container.Database.Migrate();
        }

        public async Task<List<User>> GetAllUsersAsync() 
        {
           return await _container.Users.Include(it => it.Address).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _container.Users.Include(it => it.Address).FirstOrDefaultAsync(it => it.Id == id);
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            Guid.TryParse(userId, out Guid id);
            return await _container.Users.Include(it => it.Address).FirstOrDefaultAsync(it => it.Id == id);
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            return await _container.Users.Include(it => it.Address).FirstOrDefaultAsync(it => it.Email == email);
        }

        public static bool CheckPassword (User user, string password)
        {
            password = HashPassword(password);
            return user.Password == password;
        }

        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", string.Empty);
            }
        }

        public async Task CreateUserAsync(User user)
        {
            user.Id = Guid.NewGuid();
            _container.Add(user);
            await _container.SaveChangesAsync();
        }

        public async Task AddAddressAsync(Address address)
        {
            address.Id = Guid.NewGuid();
            _container.Add(address);
            await _container.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            if(user.Address != null)
            {
                _container.Update(user.Address);
            }

            _container.Update(user);
            await _container.SaveChangesAsync();
        }

        // muss man hier auch address mit löschen ?
        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _container.Users.FindAsync(id);
            if (user != null)
            {
                _container.Users.Remove(user);
                await _container.SaveChangesAsync();
            }
        }

        public bool UserExists(Guid id)
        {
            return _container.Users.Any(e => e.Id == id);
        }

        public async Task AddFavoriteAnimalAsync(User user, Animal animal)
        {
            if (user.FavoriteAnimals == null)
            {
                user.FavoriteAnimals = new List<Animal?>();
            }

            user.FavoriteAnimals.Add(animal);
            await _container.SaveChangesAsync();
        }

        public async Task RemoveFavoriteAnimalAsync(User user, Animal animal)
        {
            if (user.FavoriteAnimals != null)
            {
                user.FavoriteAnimals.Remove(animal);
                await _container.SaveChangesAsync();
            }
        }
    }
}
