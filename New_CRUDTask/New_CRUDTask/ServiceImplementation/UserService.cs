using Microsoft.EntityFrameworkCore;
using New_CRUDTask.ExceptionHandling;
using New_CRUDTask.IServiceImplementation;
using New_CRUDTask.Model;
using New_CRUDTask.Server;

namespace New_CRUDTask.ServiceImplementation
{
    public class UserService : IUserService
    {
        private readonly DbContextServer _db;
        public UserService(DbContextServer db)
        {
            _db = db;
        }
        public void AddUser(User user)
        {
            if (user == null || _db.Users.Any(u => u.Gmail == user.Gmail))
            {
                throw new TaskException("User email is already exist or user cannot be null.");
            }
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            User? u = GetUserById(id);
            if (u == null)
            {
                throw new TaskException("User not exists.");
            }
            u.IsActive = false;
            _db.SaveChanges();
        }

        public async Task<(List<User>, int totalcount)> GetUser(int page, int pageSize)
        {
            int totalcount = _db.Users.Count();
            return (await _db.Users
                .Where(u => u.IsActive == true)
                .ToListAsync(), totalcount);
        }

        public User? GetUserById(int? id)
        {
            User? u = _db.Users.FirstOrDefault(p => p.UserId == id);
            return u;
        }

        public void UpdateUser(User user)
        {
            if (user == null || !_db.Users.Any(u => u.Gmail == user.Gmail))
            {
                throw new TaskException("User cannot be null or user not exits.");
            }
            _db.Users.Update(user);
            _db.SaveChanges();
        }

    }
}
