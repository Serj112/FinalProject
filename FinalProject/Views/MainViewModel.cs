namespace FinalProject.Views
{
    public class MainViewModel
    {
        public LoginViewModel LoginView { get; set; }


        public MainViewModel()
        {
            LoginView = new LoginViewModel();
        }
    }
}