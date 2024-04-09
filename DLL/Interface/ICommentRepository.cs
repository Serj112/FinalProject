using FinalProject.DLL.Models;

namespace FinalProject.DLL.Interface
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAll();
        Task<Comment> Get(Guid id);
        Task Create(Comment item);
        Task Update(Comment item);
        Task Delete(Comment item);
    }
}