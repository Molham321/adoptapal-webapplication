using Adoptapal.Business.Definitions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adoptapal.Business.Implementations
{
    public class FavoritAnimalsManager
    {
        private readonly AdoptapalDbContext _container;

        public FavoritAnimalsManager(AdoptapalDbContext context)
        {
            _container = context;
            _container.Database.Migrate();
        }

        public async Task<List<FavoritAnimals>> GetAllFavoritAnimalsAsync()
        {
            return await _container.FavoritAnimals.Include(it => it.Animal).ThenInclude(it => it.User).ToListAsync();
        }

        public async Task<List<FavoritAnimals>> GetAllUserFavoritAnimalsByUserAsync(User user)
        {
            return await _container.FavoritAnimals.Include(it => it.Animal).ThenInclude(it => it.User).Where(m => m.User == user).ToListAsync();
        }

        public async Task CreateFavoritAnimalAsync(FavoritAnimals favoritAnimals)
        {
            favoritAnimals.Id = Guid.NewGuid();
            _container.Add(favoritAnimals);
            await _container.SaveChangesAsync();
        }

        public async Task<bool> CheckIfFavoritAsync(FavoritAnimals favoritAnimals)
        {
            // Überprüfe, ob der Benutzer den Favoriten bereits hat
            bool isFavorit = await _container.FavoritAnimals
                .AnyAsync(f => f.User == favoritAnimals.User && f.Animal == favoritAnimals.Animal);

            return isFavorit;
        }

        public async Task<FavoritAnimals?> GetFavoritAnimal(User currentUser, Animal animal)
        {
            return await _container.FavoritAnimals
                   .FirstOrDefaultAsync(f => f.User == currentUser && f.Animal == animal);
        }

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
