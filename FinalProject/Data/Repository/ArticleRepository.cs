using FinalProject.Data.Context;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace FinalProject.Data.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly BlogContext _context;

        public ArticleRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task Add(Article article)
        {
            var entry = _context.Entry(article);
            if (entry.State == EntityState.Detached)
                await _context.Articles.AddAsync(article);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Article article)
        {
            //Удаляем пользователя по ид
            if (article.Id != null)
            {
                _context.Remove(article);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Article[]> GetArticles()
        {
            // Получим все статьи
            return await _context.Articles.ToArrayAsync();
        }

        public List<Article> GetAuthorArticles(int userId)
        {
            //Получим список статей по id автора
            var articles = new List<Article>();

            foreach (var article in _context.Articles)
            {
                if (article.UserId == userId)
                    articles.Add(article);
            }
            return articles;
        }
    }
}