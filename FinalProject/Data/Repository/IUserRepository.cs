using FinalProject.Models;

namespace FinalProject.Data.Repository
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task Delete(User user);
        Task Get (int id);
        Task Update (User user);
        Task<User[]> GetUsers();
    }
}
