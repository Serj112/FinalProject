using System;
using Microsoft.AspNetCore.Identity;
using System.Drawing;

namespace FinalProject.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string About { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public string GetFullName()
        {
            return LastName + " " + FirstName + " " + MiddleName;
        }

        public User()
        {
            About = "Меня зовут" + FirstName + ", добро пожаловать в мой блог!";
        }
    }
}
