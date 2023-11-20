using FinalProject.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Controllers
{
    public class HomeController: Controller
    {
        private readonly IBlogRepository _repo;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<HomeController> logger, IBlogRepository repo)
        {
            _logger = logger;
            _repo = repo;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Generate()
        {
            var usergen = new GenerateUsers();
            var userlist = usergen.Populate(30);

            foreach (var user in userlist)
            {
                var result = await _userManager.CreateAsync(user, "1234");

                if (!result.Succeeded)
                    continue;
            }

            return View();
        }
    }    
}
