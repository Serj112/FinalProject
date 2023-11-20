using FinalProject.Data.Repository;
using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FinalProject.ViewModels;

namespace FinalProject.Controllers
{
    public class UsersController : Controller
    {
        private IMapper _mapper;
        //private readonly IBlogRepository _repo;
        private readonly IUserRepository _repo;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUserRepository repo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repo = repo;
            _mapper = mapper;
        }


        // GET: UsersController
        public async Task<IActionResult> Index()
        {
            var users = await _repo.GetUsers();
            return View(users);
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(model);

                var result = await _userManager.CreateAsync(user, model.PasswordReg);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Пользователь");
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View("Home/Register");
        }

        public async Task<IActionResult> Delete(User user)
        {
            await _repo.Delete(user);
            return RedirectToAction("Index");
        }

        public async Task<User[]> GetUsers()
        {
            return await _repo.GetUsers();
        }

        public async Task<IActionResult> Update(User user)
        {
            await _repo.Update(user);
            return View(user);
        }

        public Task Get(int id)
        {
            return _repo.Get(id);
        }
    }
}
