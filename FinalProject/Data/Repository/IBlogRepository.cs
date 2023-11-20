using FinalProject.Models;

namespace FinalProject.Data.Repository
{
    public interface IBlogRepository
    {
        Task AddUser(User user);

        Task<User[]> GetUsers();
    }
}
