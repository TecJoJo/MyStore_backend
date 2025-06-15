namespace MyStore_backend.Models.DTO
{
    public class LoginResponseDTO
    {
        public string Message { get; set; }
        public string JwtToken { get; set; }
        public string Username { get; set; }
    }
}
