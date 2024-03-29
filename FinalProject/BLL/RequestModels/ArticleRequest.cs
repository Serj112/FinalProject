namespace FinalProject.BLL.RequestModels
{
    public class ArticleRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string BodyText { get; set; }
    }
}