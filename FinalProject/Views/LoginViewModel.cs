using System.ComponentModel.DataAnnotations;

namespace FinalProject.Views
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login", Prompt = "Введите Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль", Prompt = "Введите пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; } = false;

        public string ReturnUrl { get; set; } = string.Empty;
    }
}
