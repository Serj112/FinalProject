using FinalProject.DLL.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject
{
    public class BlogDB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }

        public BlogDB(DbContextOptions<BlogDB> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}