using FinalProject.Data.Context;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data.Repository
{
    public class TagRepository: ITagRepository
    {
        private readonly BlogContext _context;

        public TagRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task Add(Tag tag)
        {
            var entry = _context.Entry(tag);
            if (entry.State == EntityState.Detached)
                await _context.Tags.AddAsync(tag);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Tag tag)
        {
            _context.Entry(tag).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Tag tag)
        {
            //Удаляем пользователя по ид
            if (tag.Id != null)
            {
                _context.Remove(tag);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Tag[]> GetTags()
        {
            // Получим всех активных пользователей
            return await _context.Tags.ToArrayAsync();
        }

        public async Task GetTag(int Id)
        {
            await _context.FindAsync(Id);
        }
    }
}
