using JWTtokenMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWTtokenMVC.IServiceImplementation
{
    public interface IUserService
    {
        public void AddUser(User user);

        public List<User> GetAllUser();
    }
}
