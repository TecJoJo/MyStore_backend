namespace MyStore_backend.Models.DTO.Role
{
    public class RoleDto
    {
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public List<string> Permissions { get; set; }
    }
}
