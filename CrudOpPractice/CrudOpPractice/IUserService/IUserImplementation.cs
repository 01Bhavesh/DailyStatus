using CrudOpPractice.Model;

namespace CrudOpPractice.IUserService
{
    public interface IUserImplementation
    {
        public List<User> GetAll();
        public User GetById(int id);
        public void Create(User user);
        public void Update(User user);
        public void Delete(int id);
    }
}
