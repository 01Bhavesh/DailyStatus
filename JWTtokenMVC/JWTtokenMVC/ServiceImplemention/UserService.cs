using JWTtokenMVC.IServiceImplementation;
using JWTtokenMVC.Models;
using JWTtokenMVC.Server;
using Microsoft.AspNetCore.Mvc;

namespace JWTtokenMVC.ServiceImplemention
{
    public class UserService : IUserService
    {
        private readonly DbContextUser _db;
        public UserService(DbContextUser db)
        {
            _db = db;
        }
        public void AddUser(User user)
        {
            if (_db.users.Any(u => u.Email == user.Email))
            {
                throw new Exception("This User Email is already present");
            }
            _db.users.Add(user);
            _db.SaveChanges();
        }

        public List<User> GetUser()
        {
            return _db.users.ToList();
        }
    }
}
