using AutoMapper;
using FinalProject.Data.Repository;
using FinalProject.Models;
using FinalProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleRepository _repo;

        public ArticlesController(IArticleRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _repo.GetArticles();
            return View(articles);
        }

        public async Task<IActionResult> Create(Article newArticle)
        {
            await _repo.Add(newArticle);
            return View(newArticle);
        }

        public async Task<IActionResult> Delete(Article article)
        {
            await _repo.Delete(article);
            return RedirectToAction("Index");
        }

        public async Task<Article[]> GetArticles()
        {
            return await _repo.GetArticles();
        }

        public async Task<IActionResult> Update(Article article)
        {
            await _repo.Update(article);
            return View(article);
        }

        public List<Article> GetAuthorArticles(int userId)
        {
            return _repo.GetAuthorArticles(userId);
        }
    }
}
