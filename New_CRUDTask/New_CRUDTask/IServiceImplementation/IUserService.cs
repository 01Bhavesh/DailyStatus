using New_CRUDTask.Model;

namespace New_CRUDTask.IServiceImplementation
{
    public interface IUserService
    {
        Task<(List<User>, int totalcount)> GetUser(int page, int pageSize);
        User? GetUserById(int? id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
