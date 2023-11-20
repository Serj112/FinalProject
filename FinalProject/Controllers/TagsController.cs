using FinalProject.Data.Repository;
using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagRepository _repo;

        public TagsController(ITagRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var tags = await _repo.GetTags();
            return View(tags);
        }

        public async Task<IActionResult> Create(Tag newTag)
        {
            await _repo.Add(newTag);
            return View(newTag);
        }

        public async Task<IActionResult> Delete(Tag tag)
        {
            await _repo.Delete(tag);
            return RedirectToAction("Index");
        }

        public async Task<Tag[]> GetTags()
        {
            return await _repo.GetTags();
        }

        public async Task<IActionResult> Update(Tag tag)
        {
            await _repo.Update(tag);
            return View(tag);
        }

        public Task GetTag(int id)
        {
            return _repo.GetTag(id);
        }
    }
}
