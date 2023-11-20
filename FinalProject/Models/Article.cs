using Microsoft.AspNet.Identity.EntityFramework;

namespace FinalProject.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
