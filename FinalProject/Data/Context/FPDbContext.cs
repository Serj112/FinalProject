/* using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.Services.Users;

namespace FinalProject.Data.Context
{
    public class FPDbContext : IdentityDbContext<User>
    {
        public FPDbContext(DbContextOptions<FPDbContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
} */