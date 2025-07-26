using CrudOpPractice.Connection;
using CrudOpPractice.IUserService;
using CrudOpPractice.Model;

namespace CrudOpPractice.UserService
{
    public class UserImplementation : IUserImplementation
    {
        private readonly ConDB _db;

        public UserImplementation(ConDB db)
        {
            _db = db;
        }
        public void Create(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = _db.Users.FirstOrDefault(u => u.Id == id);
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public List<User> GetAll()
        {
            List<User> lst = _db.Users.ToList();
            return lst;
        }

        public User GetById(int id)
        {
            User user = _db.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public void Update(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }
    }
}
