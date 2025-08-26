namespace MyStore_backend.Models.DTO.Role
{
    public class AddPermissionsResponseDto
    {
        public string roleId { get; set; }
        public string roleName { get; set; }
        public List<string> AddedPermissions { get; set; } = new List<string>();
    }
}
