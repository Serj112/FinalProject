using FinalProject.Data.Repository;
using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentRepository _repo;

        public CommentsController(ICommentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var comments = await _repo.GetComments();
            return View(comments);
        }

        public async Task<IActionResult> Create(Comment newComment)
        {
            await _repo.Add(newComment);
            return View(newComment);
        }

        public async Task<IActionResult> Delete(Comment comment)
        {
            await _repo.Delete(comment);
            return RedirectToAction("Index");
        }

        public async Task<Comment[]> GetComments()
        {
            return await _repo.GetComments();
        }

        public async Task<IActionResult> Update(Comment comment)
        {
            await _repo.Update(comment);
            return View(comment);
        }

        public Task GetComment(int id)
        {
            return _repo.GetComment(id);
        }
    }
}
