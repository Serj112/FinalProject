using FinalProject.DLL.Models;

namespace FinalProject.DLL.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(Guid id);
        Task<User> GetByLogin(string login);
        Task Create(User item);
        Task Update(User item);
        Task Delete(User item);
    }
}