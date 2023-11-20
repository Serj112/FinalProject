using FinalProject.Models;

namespace FinalProject.Data.Repository
{
    public interface ICommentRepository
    {
        Task Add(Comment comment);
        Task Delete(Comment comment);
        Task GetComment(int id);
        Task Update(Comment comment);
        Task<Comment[]> GetComments();
    }
}
