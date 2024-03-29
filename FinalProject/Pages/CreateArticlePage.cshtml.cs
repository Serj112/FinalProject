using AutoMapper;
using FinalProject.DLL.Interface;
using FinalProject.DLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Pages
{
    public class CreateArticlePageModel : PageModel
    {
        private IArticleRepository articles;
        private ITagRepository tags;
        private IMapper mapper;


        public List<CheckTag> CheckTags { get; set; }

        [Required]
        [Display(Name = "Íàçâàíèå", Prompt = "Ââåäèòå íàçâàíèå")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Òåêñò", Prompt = "Ââåäèòå òåêñò")]
        public string ArticleBody { get; set; }

        [Display(Name = "Îïèñàíèå", Prompt = "Ââåäèòå îïèñàíèå")]
        public string Comment { get; set; }

        public CreateArticlePageModel(IArticleRepository articleRepository, ITagRepository tagRepository, IMapper mapper)
        {
            articles = articleRepository;
            tags = tagRepository;
            this.mapper = mapper;
        }

        public void OnGet()
        {
            CheckTags = new List<CheckTag>();
            var allTags = tags.GetAll().Result;

            foreach (var existTag in allTags)
            {
                var tmp = new CheckTag();
                tmp.RememberMe = false;
                tmp.tagName = existTag.TagName;
                CheckTags.Add(tmp);
            }
        }

        public void OnPost()
        {

        }
    }

    public class CheckTag
    {
        public bool RememberMe { get; set; } = false;
        public string tagName { get; set; }
        public CheckTag(bool rememberMe, Tag tag)
        {
            RememberMe = rememberMe;
            this.tagName = tag.TagName;
        }

        public CheckTag() { }
    }
}