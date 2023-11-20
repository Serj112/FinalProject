using FinalProject.Models;
using System.Collections.Generic;

namespace FinalProject.Data.Repository
{
    public interface IArticleRepository
    {
        Task Add(Article article);
        Task Delete(Article article);
        List<Article> GetAuthorArticles(int userId); //Получение статей по автору
        Task Update(Article article);
        Task<Article[]> GetArticles();
    }
}
