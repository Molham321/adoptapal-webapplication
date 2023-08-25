/*
 * File: AnimalManager.cs
 * Namespace: Adoptapal.Business.Implementations
 * 
 * Description:
 * This file contains the implementation of the AnimalManager class responsible for managing
 * operations related to animal entities. It includes methods for CRUD operations on animals,
 * retrieval of animal data, and checking for the existence of an animal.
 * 
 */

using Adoptapal.Business.Definitions;
using Microsoft.EntityFrameworkCore;

namespace Adoptapal.Business.Implementations
{
    /// <summary>
    /// Manager class for managing operations related to animal entities.
    /// </summary>
    public class AnimalManager
    {
        private readonly AdoptapalDbContext _container;

        /// <summary>
        /// Initializes a new instance of the AnimalManager class.
        /// </summary>
        /// <param name="context">The database context instance.</param>
        public AnimalManager(AdoptapalDbContext context)
        {
            _container = context;
            _container.Database.Migrate();
        }

        /// <summary>
        /// Retrieves a list of all animals asynchronously, including associated user information.
        /// </summary>
        /// <returns>A list of animals.</returns>
        public async Task<List<Animal>> GetAllAnimalsAsync()
        {
            return await _container.Animals.Include(it => it.User).ToListAsync();
        }

        /// <summary>
        /// Retrieves a list of all animals associated with a specific user asynchronously.
        /// </summary>
        /// <param name="user">The user for whom to retrieve animals.</param>
        /// <returns>A list of animals associated with the user.</returns>
        public async Task<List<Animal>> GetAllUserAnimalsByUserAsync(User user)
        {
            return await _container.Animals.Where(m => m.User == user).ToListAsync();
        }

        /// <summary>
        /// Retrieves an animal by its unique identifier asynchronously, including associated user information.
        /// </summary>
        /// <param name="id">The unique identifier of the animal to retrieve.</param>
        /// <returns>The animal entity.</returns>
        public async Task<Animal> GetAnimalByIdAsync(Guid id)
        {
            return await _container.Animals.Include(it => it.User).FirstOrDefaultAsync(m => m.Id == id);
        }

        /// <summary>
        /// Creates a new animal asynchronously.
        /// </summary>
        /// <param name="animal">The animal entity to create.</param>
        public async Task CreateAnimalAsync(Animal animal)
        {
            animal.Id = Guid.NewGuid();
            _container.Add(animal);
            await _container.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing animal asynchronously.
        /// </summary>
        /// <param name="animal">The animal entity to update.</param>
        public async Task UpdateAnimalAsync(Animal animal)
        {
            _container.Update(animal);
            await _container.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an animal by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the animal to delete.</param>
        public async Task DeleteAnimalAsync(Guid id)
        {
            // Remove the animal from favorites first
            var favoritAnimalsToDelete = await _container.FavoritAnimals
                .Where(f => f.Animal.Id == id)
                .ToListAsync();

            foreach (var favoritAnimal in favoritAnimalsToDelete)
            {
                _container.FavoritAnimals.Remove(favoritAnimal);
            }

            var animal = await _container.Animals.FindAsync(id);
            if (animal != null)
            {
                _container.Animals.Remove(animal);
                await _container.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Checks if an animal with the specified unique identifier exists.
        /// </summary>
        /// <param name="id">The unique identifier to check.</param>
        /// <returns>True if the animal exists; otherwise, false.</returns>
        public bool AnimalExists(Guid id)
        {
            return (_container.Animals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
