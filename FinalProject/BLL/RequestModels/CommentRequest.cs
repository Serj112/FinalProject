namespace FinalProject.BLL.RequestModels
{
    public class CommentRequest
    {
        public Guid Id { get; set; }
        public string BodyText { get; set; }
        public Guid articleId { get; set; }
    }
}