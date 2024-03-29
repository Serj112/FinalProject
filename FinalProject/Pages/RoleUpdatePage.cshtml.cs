using AutoMapper;
using FinalProject.DLL.Interface;
using FinalProject.DLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FinalProject.Pages
{
    public class RoleUpdatePageModel : PageModel
    {
        private IRoleRepository roles;
        private IMapper mapper;

        public Role role = null;

        [Required]
        [Display(Name = "Íàçâàíèå", Prompt = "Ââåäèòå íàçâàíèå")]
        public string Name { get; set; }

        [Display(Name = "Îïèñàíèå", Prompt = "Ââåäèòå îïèñàíèå")]
        public string Comment { get; set; }

        public object? Id { get; private set; }

        public RoleUpdatePageModel(IRoleRepository roles, IMapper mapper)
        {
            this.roles = roles;
            this.mapper = mapper;
        }

        public async void OnGet()
        {
            Id = RouteData.Values["id"];
            Guid guid = (Guid)TypeDescriptor.GetConverter(typeof(Guid)).ConvertFromString((string)RouteData.Values["id"]);
            role = await roles.Get(guid);
        }
    }
}