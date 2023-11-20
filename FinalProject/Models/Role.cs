using System.Collections;

namespace FinalProject.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection Users { get; set; }
    }
}
