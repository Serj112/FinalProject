using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FinalProject.Data.Repository;
using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FinalProject.ViewModels;
using NUnit.Framework;

namespace FinalProject.Controllers
{
    public class RoleController : Controller
    {
        private IMapper _mapper;
        //private readonly IBlogRepository _repo;
        private readonly IUserRepository _repo;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RoleController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUserRepository repo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IActionResult> SeedRoles(RoleController roleManager)
        {
            var roles = new List { "Админ", "Модератор", "Пользователь" };

            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
