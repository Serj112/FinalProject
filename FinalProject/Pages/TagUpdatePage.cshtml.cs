using AutoMapper;
using FinalProject.DLL.Interface;
using FinalProject.DLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FinalProject.Pages
{
    public class TagUpdatePageModel : PageModel
    {
        private ITagRepository tags;
        private IMapper mapper;
        public Tag tag { get; set; }
        public object? Id { get; private set; }

        [Required]
        [Display(Name = "Íàçâàíèå", Prompt = "Ââåäèòå íàçâàíèå")]
        public string Name { get; set; }

        [Display(Name = "Îïèñàíèå", Prompt = "Ââåäèòå îïèñàíèå")]
        public string? Comment { get; set; }

        public TagUpdatePageModel(ITagRepository tags, IMapper mapper)
        {
            this.tags = tags;
            this.mapper = mapper;
        }
        public async Task OnGetAsync()
        {
            Id = RouteData.Values["id"];
            Guid guid = (Guid)TypeDescriptor.GetConverter(typeof(Guid)).ConvertFromString((string)RouteData.Values["id"]);
            tag = await tags.Get(guid);
        }
    }
}
