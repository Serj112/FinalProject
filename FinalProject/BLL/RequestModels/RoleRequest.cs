namespace FinalProject.BLL.RequestModels
{
    public class RoleRequest
    {
        public RoleRequest()
        {
        }

        public RoleRequest(Guid Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}