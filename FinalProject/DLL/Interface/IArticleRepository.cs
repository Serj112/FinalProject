using FinalProject.DLL.Models;

namespace FinalProject.DLL.Interface
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAll();
        Task<Article> Get(Guid id);
        Task Create(Article item);
        Task Update(Article item);
        Task Delete(Article item);
        Task<IEnumerable<Article>> GetAllByAuthorId(Guid authorGuid);
    }
}
