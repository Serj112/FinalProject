namespace FinalProject.DLL.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string TagName { get; set; }

        // Связь с статьями
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}