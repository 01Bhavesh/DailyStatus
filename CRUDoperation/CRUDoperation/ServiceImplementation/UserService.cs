using CRUDoperation.IServiceImplementation;
using CRUDoperation.Model;
using CRUDoperation.Server;
using Microsoft.EntityFrameworkCore;

namespace CRUDoperation.ServiceImplementation
{
    public class UserService : IUserService
    {
        private readonly DbProduct _db;
        public UserService(DbProduct db)
        {
            _db = db;
        }
        public async Task<bool> CreateUser(User user)
        {
            if (_db.Users.Any(p => p.Email == user.Email))
            {
                return false;
            }
            _db.Users.Add(user);
            _db.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteUser(int Id)
        {
            User? user = await _db.Users.FirstOrDefaultAsync(p => p.Id == Id);
            if (user == null)
            {
                return false;
            }
            user.IsActive = false;
            _db.SaveChanges();
            return true;
        }

        public async Task<IList<User>> GetAllUser()
        {
            IList<User> lst = await _db.Users.Where(u => u.IsActive).ToListAsync();
            return lst;
        }

        public async Task<User> GetUserById(int? id)
        {
            User? user = await _db.Users.FirstOrDefaultAsync(p => p.Id == id);
            return user;
        }

        public async Task<bool> UpdateUser(User user)
        {
            User? u = await _db.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (u == null)
            {
                return false;
            }
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
