
using Adoptapal.Business.Definitions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System;
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

        public IQueryable<User> GetList() 
        {
           return _container.Users.Include(it => it.Address).AsQueryable();
        }

        public User? GetUser(Guid id)
        {
            return _container.Users.Include(it => it.Address).FirstOrDefault(it => it.Id == id);
        }

        public User FindByEmail(string email)
        {
            return _container.Users.Include(it => it.Address).FirstOrDefault(it => it.Email == email);
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


        public void Add(User user)
        {
            user.Id = Guid.NewGuid();
            _container.Users.Add(user);
            _container.SaveChanges();
        }

        public void AddAddress(Address address)
        {
            address.Id = Guid.NewGuid();
            _container.Address.Add(address);
            _container.SaveChanges();
        }

        public void Update(User user)
        {
            _container.Address.Update(user.Address);
            _container.Users.Update(user);
            _container.SaveChanges();
        }

        // muss man hier auch address mit löschen ?
        public void Delete(Guid id)
        {
            var user = _container.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _container.Users.Remove(user);
                _container.SaveChanges();
            }
        }
    }
}
