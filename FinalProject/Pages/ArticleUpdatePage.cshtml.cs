using AutoMapper;
using FinalProject.DLL.Interface;
using FinalProject.DLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace FinalProject.Pages
{
    public class ArticleUpdatePageModel : PageModel
    {
        private IArticleRepository _articles;
        private ITagRepository _tags;
        private ICommentRepository _comments;
        private IMapper _mapper;
        public List<CheckTag> CheckTags { get; set; }
        public object? Id { get; private set; }

        public Article article { get; set; }

        [Required]
        [Display(Name = "Íàçâàíèå", Prompt = "Ââåäèòå íàçâàíèå")]
        public string Name { get; set; }

        [Required]
        public string ArticleBody { get; set; }

        [Display(Name = "Îïèñàíèå", Prompt = "Ââåäèòå îïèñàíèå")]
        public string Comment { get; set; }

        public ArticleUpdatePageModel(IArticleRepository articleRepository, ITagRepository tagRepository, ICommentRepository commentRepository, IMapper mapper)
        {
            _articles = articleRepository;
            _tags = tagRepository;
            _comments = commentRepository;
            _mapper = mapper;
        }

        public async void OnGet()
        {
            Id = RouteData.Values["id"];
            Guid guid = (Guid)TypeDescriptor.GetConverter(typeof(Guid)).ConvertFromString((string)RouteData.Values["id"]);
            article = await _articles.Get(guid);

            CheckTags = new List<CheckTag>();
            var allTags = _tags.GetAll().Result;

            foreach (var existTag in allTags)
            {
                var tmp = new CheckTag();
                tmp.RememberMe = false;
                tmp.tagName = existTag.TagName;
                CheckTags.Add(tmp);
            }
        }
    }
}
