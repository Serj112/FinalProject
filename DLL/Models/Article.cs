﻿using System.Xml.Linq;

namespace FinalProject.DLL.Models
{
    public class Article
    {
        // Общее
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string BodyText { get; set; }

        // Автор - привязка к User
        public Guid? Author_Id { get; set; }
        public User? Author { get; set; }

        // Привязка тэгов и комментариев
        public List<Tag>? Tags { get; set; } = new List<Tag>();
        public List<Comment>? Comments { get; set; } = new List<Comment>();
    }
}