using FinalProject.BLL.RequestModels;
using FinalProject.DLL.Models;
using FinalProject.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public interface IAccountController
    {
        public Task<User> Authenticate(UserRequest request, string login, string password);
        public Task<IActionResult> Login(LoginViewModel model);
        public Task<IActionResult> Registration(RegistrationViewModel model);
        public Task<User> GetCurrentUser();
    }
}