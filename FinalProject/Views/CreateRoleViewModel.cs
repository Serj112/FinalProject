using System.ComponentModel.DataAnnotations;

namespace FinalProject.Views
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Название", Prompt = "Введите название")]
        public string Name { get; set; }

        [Display(Name = "Описание", Prompt = "Введите описание")]
        public string Comment { get; set; }
    }
}