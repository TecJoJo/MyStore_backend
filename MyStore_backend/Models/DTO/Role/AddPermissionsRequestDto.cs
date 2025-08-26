namespace MyStore_backend.Models.DTO.Role
{
    public class AddPermissionsRequestDto
    {
        public List<string> Permissions { get; set; } = new List<string>();
    }
}
