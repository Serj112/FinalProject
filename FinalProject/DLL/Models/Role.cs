namespace FinalProject.DLL.Models
{
    public class Role
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        // Привязываю пользователей многие ко многим
        public List<User> Users { get; set; } = new List<User>();
    }
}