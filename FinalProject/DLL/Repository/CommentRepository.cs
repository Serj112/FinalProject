﻿using FinalProject.DLL.Interface;
using FinalProject.DLL.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.DLL.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDB _db;

        public CommentRepository(BlogDB db)
        {
            _db = db;
        }

        public async Task Create(Comment item)
        {
            var entry = _db.Entry(item);
            if (entry.State == EntityState.Detached)
                _db.Comments.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Comment item)
        {
            _db.Comments.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<Comment> Get(Guid id)
        {
            return await _db.Comments
                                .Include(x => x.Author)
                                .Include(x => x.Article)
                                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _db.Comments
                                .Include(x => x.Author)
                                .Include(x => x.Article)
                                .ToListAsync();
        }

        public async Task Update(Comment item)
        {
            var oldItem = Get(item.Id);

            if (!string.IsNullOrEmpty(item.BodyText))
                oldItem.Result.BodyText = item.BodyText;

            var entry = _db.Entry(oldItem.Result);

            if (entry.State == EntityState.Detached)
                _db.Comments.Update(item);
            await _db.SaveChangesAsync();
        }
    }
}