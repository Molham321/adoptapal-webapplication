/*
 * File: FavoritAnimalsManager.cs
 * Namespace: Adoptapal.Business.Implementations
 * 
 * Description:
 * This file contains the implementation of the FavoritAnimalsManager class responsible for managing
 * operations related to favorite animal entities. It includes methods for CRUD operations on favorite animals,
 * retrieval of favorite animal data, and checking for the existence of a favorite animal.
 * 
 */

using Adoptapal.Business.Definitions;
using Microsoft.EntityFrameworkCore;

namespace Adoptapal.Business.Implementations
{
    /// <summary>
    /// Manager class for managing operations related to favorite animal entities.
    /// </summary>
    public class FavoritAnimalsManager
    {
        private readonly AdoptapalDbContext _container;

        /// <summary>
        /// Initializes a new instance of the FavoritAnimalsManager class.
        /// </summary>
        /// <param name="context">The database context instance.</param>
        public FavoritAnimalsManager(AdoptapalDbContext context)
        {
            _container = context;
            _container.Database.Migrate();
        }

        /// <summary>
        /// Retrieves a list of all favorite animals asynchronously, including associated animal and user information.
        /// </summary>
        /// <returns>A list of favorite animals.</returns>
        public async Task<List<FavoritAnimals>> GetAllFavoritAnimalsAsync()
        {
            return await _container.FavoritAnimals.Include(it => it.Animal).ThenInclude(it => it.User).ToListAsync();
        }

        /// <summary>
        /// Retrieves a list of all favorite animals associated with a specific user asynchronously, including associated animal information.
        /// </summary>
        /// <param name="user">The user for whom to retrieve favorite animals.</param>
        /// <returns>A list of favorite animals associated with the user.</returns>
        public async Task<List<FavoritAnimals>> GetAllUserFavoritAnimalsByUserAsync(User user)
        {
            return await _container.FavoritAnimals.Include(it => it.Animal).ThenInclude(it => it.User).Where(m => m.User == user).ToListAsync();
        }

        /// <summary>
        /// Creates a new favorite animal asynchronously.
        /// </summary>
        /// <param name="favoritAnimals">The favorite animal entity to create.</param>
        public async Task CreateFavoritAnimalAsync(FavoritAnimals favoritAnimals)
        {
            favoritAnimals.Id = Guid.NewGuid();
            _container.Add(favoritAnimals);
            await _container.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if a user has favorited a specific animal asynchronously.
        /// </summary>
        /// <param name="favoritAnimals">The favorite animal entity to check.</param>
        /// <returns>True if the user has favorited the animal; otherwise, false.</returns>
        public async Task<bool> CheckIfFavoritAsync(FavoritAnimals favoritAnimals)
        {
            // Check if the user has already favorited the animal
            bool isFavorit = await _container.FavoritAnimals
                .AnyAsync(f => f.User == favoritAnimals.User && f.Animal == favoritAnimals.Animal);

            return isFavorit;
        }

        /// <summary>
        /// Retrieves a favorite animal based on the user and animal asynchronously.
        /// </summary>
        /// <param name="currentUser">The current user entity.</param>
        /// <param name="animal">The animal entity.</param>
        /// <returns>The favorite animal entity, if found; otherwise, null.</returns>
        public async Task<FavoritAnimals?> GetFavoritAnimal(User currentUser, Animal animal)
        {
            return await _container.FavoritAnimals
                   .FirstOrDefaultAsync(f => f.User == currentUser && f.Animal == animal);
        }

        /// <summary>
        /// Deletes a favorite animal by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the favorite animal to delete.</param>
        public async Task DeleteFavoritAnimalAsync(Guid id)
        {
            var favoritAnimal = await _container.FavoritAnimals.FindAsync(id);
            if (favoritAnimal != null)
            {
                _container.FavoritAnimals.Remove(favoritAnimal);
                await _container.SaveChangesAsync();
            }
        }
    }
}
