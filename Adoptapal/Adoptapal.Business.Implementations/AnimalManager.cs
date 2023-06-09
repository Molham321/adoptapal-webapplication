using Adoptapal.Business.Definitions;
using Microsoft.EntityFrameworkCore;

namespace Adoptapal.Business.Implementations
{
    public class AnimalManager
    {
        private readonly AdoptapalDbContext _container;

        public AnimalManager(AdoptapalDbContext context)
        {
            _container = context;
            _container.Database.Migrate();
        }

        public async Task<List<Animal>> GetAllAnimalsAsync()
        {
            return await _container.Animals.ToListAsync();
        }

        public async Task<List<Animal>> GetAllUserAnimalsByUserAsync(User user)
        {
            return await _container.Animals.Where(m => m.User == user).ToListAsync();
        }

        public async Task<Animal> GetAnimalByIdAsync(Guid id)
        {
            return await _container.Animals.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateAnimalAsync(Animal animal)
        {
            animal.Id = Guid.NewGuid();
            _container.Add(animal);
            await _container.SaveChangesAsync();
        }

        public async Task UpdateAnimalAsync(Animal animal)
        {
            _container.Update(animal);
            await _container.SaveChangesAsync();
        }

        public async Task DeleteAnimalAsync(Guid id)
        {
            var animal = await _container.Animals.FindAsync(id);
            if (animal != null)
            {
                _container.Animals.Remove(animal);
                await _container.SaveChangesAsync();
            }
        }

        public bool AnimalExists(Guid id)
        {
            return _container.Animals.Any(e => e.Id == id);
        }

    }
}
