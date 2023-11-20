using FinalProject.Data.Context;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogContext _context;

        public CommentRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task Add(Comment comment)
        {
            var entry = _context.Entry(comment);
            if (entry.State == EntityState.Detached)
                await _context.Comments.AddAsync(comment);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Comment comment)
        {
            //Удаляем пользователя по ид
            if (comment.Id != null)
            {
                _context.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Comment[]> GetComments()
        {
            // Получим всех активных пользователей
            return await _context.Comments.ToArrayAsync();
        }

        public async Task GetComment(int Id)
        {
            await _context.FindAsync(Id);
        }
    }
}
