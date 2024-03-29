using FinalProject.DLL.Models;

namespace FinalProject.DLL.Interface
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAll();
        Task<Role> Get(Guid id);
        Task Create(Role item);
        Task Update(Role item);
        Task Delete(Role item);
        Task<Role> GetByName(string name);
    }
}
