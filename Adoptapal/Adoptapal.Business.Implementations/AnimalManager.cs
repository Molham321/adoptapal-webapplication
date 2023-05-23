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

        public IQueryable<Animal> GetList()
        {
            return _container.Animals.AsQueryable();
        }

        public Animal? GetAnimal(Guid id)
        {
            return _container.Animals.FirstOrDefault(it => it.Id == id);
        }

        public Animal FindByName(string name)
        {
            return _container.Animals.FirstOrDefault(it => it.Name == name);
        }

        // hier weitere Datenbankoperationen

        public void Add(Animal animal)
        {
            animal.Id = Guid.NewGuid();
            _container.Animals.Add(animal);
            _container.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var animal = _container.Animals.FirstOrDefault(x => x.Id == id);
            if (animal != null)
            {
                _container.Animals.Remove(animal);
                _container.SaveChanges();
            }
        }
    }
}
