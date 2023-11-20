using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data.Context
{
    public class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Role> Roles { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Article>().ToTable("Articles");
            builder.Entity<Comment>().ToTable("Comments");
            builder.Entity<Tag>().ToTable("Tags");
            builder.Entity<Role>().ToTable("Roles");

            builder.Entity<Role>()
                   .HasOne(u => u.Name)
                   .WithMany(u => u.Users)
                   .HasForeignKey(u => u.Id);
        }

        internal Task FindAsync(int userId)
        {
            throw new NotImplementedException();
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer("Server=DESKTOP-2KH5EO9\\D:\\Programming\\SQLite;Database=FinalProject;Trusted_Connection=True;");
         } */
    }
}
