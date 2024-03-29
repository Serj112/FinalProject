using FinalProject.DLL.Models;

namespace FinalProject.DLL.Interface
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAll();
        Task<Tag> Get(Guid id);
        Task Create(Tag item);
        Task Update(Tag item);
        Task Delete(Tag item);
    }
}