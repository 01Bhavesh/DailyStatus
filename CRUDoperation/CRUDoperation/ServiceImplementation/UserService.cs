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
            if (await _db.Users.AnyAsync(p => p.Email == user.Email))
            {
                return false;
            }
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(int Id) // Change to DisableUser if needed
        {
            var user = await _db.Users.FindAsync(Id);
            if (user == null)
            {
                return false;
            }
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IList<User>> GetAllUser()
        {
            return await _db.Users.Where(u => u.IsActive).ToListAsync();
        }

        public async Task<User?> GetUserById(int? id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<bool> UpdateUser(User user)
        {
            var existingUser = await _db.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                return false;
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.IsActive = user.IsActive;

            await _db.SaveChangesAsync();
            return true;
        }
    }
}
