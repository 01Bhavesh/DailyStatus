using CRUDoperation.Model;

namespace CRUDoperation.IServiceImplementation
{
    public interface IUserService
    {
        Task<IList<User>> GetAllUser();
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int Id);
        Task<User> GetUserById(int? id);
    }
}
