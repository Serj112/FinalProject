using FinalProject.Models;

namespace FinalProject.Data.Repository
{
    public interface ITagRepository
    {
        Task Add(Tag tag);
        Task Delete(Tag tag);
        Task GetTag(int id);
        Task Update(Tag tag);
        Task<Tag[]> GetTags();
    }
}
