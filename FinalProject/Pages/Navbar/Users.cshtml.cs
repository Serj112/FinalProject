using AutoMapper;
using FinalProject.DLL.Interface;
using FinalProject.DLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages.Navbar
{
    public class UsersModel : PageModel
    {
        private IUserRepository _users;
        private IRoleRepository _roles;
        private IMapper mapper;

        public List<User> users { get; set; }
        public List<Role> roles { get; set; }

        public UsersModel(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            _users = userRepository;
            _roles = roleRepository;
            this.mapper = mapper;
        }

        public async void OnGet()
        {
            users = new List<User>();
            roles = new List<Role>();

            var allUsers = _users.GetAll().Result;
            var allRoles = _roles.GetAll().Result;
            users.AddRange(allUsers);
            roles.AddRange(allRoles);
        }
    }
}